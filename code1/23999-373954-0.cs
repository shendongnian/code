    static partial class FileExporter
    {
        private enum CellStyle { General, Number, Currency, DateTime, ShortDate };
        private static void WriteExcelHeader(StreamWriter fs)
        {
            fs.WriteLine("<?xml version=\"1.0\"?>");
            fs.WriteLine("<?mso-application progid=\"Excel.Sheet\"?>");
            fs.WriteLine("<ss:Workbook xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">");
        }
        private static void WriteExcelStyles(StreamWriter fs)
        {
            fs.WriteLine("  <ss:Styles>");
            fs.WriteLine("    <ss:Style ss:ID=\"{0}\" />", CellStyle.General);
            fs.WriteLine("    <ss:Style ss:ID=\"{0}\"><ss:NumberFormat ss:Format=\"General Number\" /></ss:Style>", CellStyle.Number);
            fs.WriteLine("    <ss:Style ss:ID=\"{0}\"><ss:NumberFormat ss:Format=\"General Date\" /></ss:Style>", CellStyle.DateTime);
            fs.WriteLine("    <ss:Style ss:ID=\"{0}\"><ss:NumberFormat ss:Format=\"Currency\" /></ss:Style>", CellStyle.Currency);
            fs.WriteLine("    <ss:Style ss:ID=\"{0}\"><ss:NumberFormat ss:Format=\"Short Date\" /></ss:Style>", CellStyle.ShortDate);
            fs.WriteLine("  </ss:Styles>");
        }
        static public void OpenFile(String fileName)
        {
            try
            {
                //try to open the file with its default association
                Process p = new Process();
                p.StartInfo.FileName = fileName;
                p.Start();
            }
            catch
            {
                MessageBox.Show("There was an error opening the file. It should, however, still be saved.", "Excel Export", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public static void ExcelExport(DataGridView dataGrid, String fileName, bool openAfter)
        {
            //export a DataGridView to Excel
            DialogResult retry = DialogResult.Retry;
            while (retry == DialogResult.Retry)
            {
                try
                {
                    using (StreamWriter fs = new StreamWriter(fileName))
                    {
                        WriteExcelHeader(fs);
                        WriteExcelStyles(fs);
                        // Write the worksheet contents
                        fs.WriteLine("<ss:Worksheet ss:Name=\"Sheet1\">");
                        fs.WriteLine("  <ss:Table>");
                        //Write column definitions - width based on the data grid column width
                        foreach (DataGridViewColumn col in dataGrid.Columns)
                            if (col.Visible)
                                fs.WriteLine("    <ss:Column ss:Width=\"{0}\"/>", col.Width);
                        //Write header row
                        fs.WriteLine("    <ss:Row>");
                        foreach (DataGridViewColumn col in dataGrid.Columns)
                            if (col.Visible)
                                fs.WriteLine("      <ss:Cell><ss:Data ss:Type=\"String\">{0}</ss:Data></ss:Cell>", col.HeaderText);
                        fs.WriteLine("    </ss:Row>");
                        //write data
                        foreach (DataGridViewRow row in dataGrid.Rows)
                        {
                            fs.WriteLine("    <ss:Row>");
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                if (cell.Visible)
                                    WriteExcelCellTag(fs, cell);
                            }
                            fs.WriteLine("    </ss:Row>");
                        }
                        // Close up the document
                        fs.WriteLine("  </ss:Table>");
                        fs.WriteLine("</ss:Worksheet>");
                        fs.WriteLine("</ss:Workbook>");
                        fs.Close();
                        if (openAfter)
                            OpenFile(fileName);
                        retry = DialogResult.Cancel;
                    }
                }
                catch (Exception myException)
                {
                    retry = MessageBox.Show(myException.Message, "Excel Export", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                }
            }
        }
        private static void WriteExcelCellTag(StreamWriter fs, DataGridViewCell cell)
        {
            //overloaded - write the <ss:Cell> and <ss:Data> tags for DataGridViewCell
            WriteExcelCellTag(fs, cell.Value);
        }
        public static void ExcelExport(DataTable data, String fileName, bool openAfter)
        {
            //export a DataTable to Excel
            DialogResult retry = DialogResult.Retry;
            while (retry == DialogResult.Retry)
            {
                try
                {
                    using (StreamWriter fs = new StreamWriter(fileName))
                    {
                        WriteExcelHeader(fs);
                        WriteExcelStyles(fs);
                        // Write the worksheet contents
                        fs.WriteLine("<ss:Worksheet ss:Name=\"Sheet1\">");
                        fs.WriteLine("  <ss:Table>");
                        //Write column definitions - no width definitions for a DataTable so nothing goes here
                        /*foreach (DataColumn col in data.Columns)
                            fs.WriteLine("    <ss:Column ss:Width=\"{0}\"/>", col.Width);*/
                        //Write header row
                        fs.WriteLine("    <ss:Row>");
                        foreach (DataColumn col in data.Columns)
                            fs.WriteLine("      <ss:Cell><ss:Data ss:Type=\"String\">{0}</ss:Data></ss:Cell>", col.Caption);
                        fs.WriteLine("    </ss:Row>");
                        //write data
                        foreach (DataRow row in data.Rows)
                        {
                            fs.WriteLine("    <ss:Row>");
                            foreach (Object o in row.ItemArray)
                            {
                                WriteExcelCellTag(fs, o);
                            }
                            fs.WriteLine("    </ss:Row>");
                        }
                        // Close up the document
                        fs.WriteLine("  </ss:Table>");
                        fs.WriteLine("</ss:Worksheet>");
                        fs.WriteLine("</ss:Workbook>");
                        fs.Close();
                        if (openAfter)
                            OpenFile(fileName);
                        retry = DialogResult.OK;
                    }
                }
                catch (Exception myException)
                {
                    retry = MessageBox.Show(myException.Message, "Excel Export", MessageBoxButtons.RetryCancel, MessageBoxIcon.Asterisk);
                }
            }
        }
        private static void WriteExcelCellTag(StreamWriter fs, Object o)
        {
            //write the <ss:Cell> and <ss:Data> tags for something
            String tag = "      <ss:Cell ss:StyleID=\"";
            if (o is Int16 || o is Int32 || o is Int64 || o is SByte ||
                o is UInt16 || o is UInt32 || o is UInt64 || o is Byte)
            {
                tag += String.Format("{1}\"><ss:Data ss:Type=\"Number\">{0}</ss:Data>", o, CellStyle.Number);
            }
            else if (o is Single || o is Double || o is Decimal) //we'll assume it's a currency
            {
                tag += String.Format("{1}\"><ss:Data ss:Type=\"Number\">{0}</ss:Data>", o, CellStyle.Currency);
            }
            else if (o is DateTime)
            {
                //check if there's no time information and use the appropriate style
                tag += String.Format("{1}\"><ss:Data ss:Type=\"DateTime\">{0:yyyy\\-MM\\-dd\\THH\\:mm\\:ss\\.fff}</ss:Data>", o,
                ((DateTime)o).TimeOfDay.CompareTo(new TimeSpan(0, 0, 0, 0, 0)) == 0 ? CellStyle.ShortDate : CellStyle.DateTime);
            }
            else
            {
                tag += String.Format("{1}\"><ss:Data ss:Type=\"String\">{0}</ss:Data>", o, CellStyle.General);
            }
            tag += "</ss:Cell>";
            fs.WriteLine(tag);
        }
    }
