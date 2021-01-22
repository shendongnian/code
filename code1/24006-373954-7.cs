    public static void ExcelExport(DataTable data, String fileName, bool openAfter)
    {
        //export a DataTable to Excel
        DialogResult retry = DialogResult.Retry;
        while (retry == DialogResult.Retry)
        {
            try
            {
                using (ExcelWriter writer = new ExcelWriter(fileName))
                {
                    writer.WriteStartDocument();
                    // Write the worksheet contents
                    writer.WriteStartWorksheet("Sheet1");
                    //Write header row
                    writer.WriteStartRow();
                    foreach (DataColumn col in data.Columns)
                        writer.WriteExcelUnstyledCell(col.Caption);
                    writer.WriteEndRow();
                    //write data
                    foreach (DataRow row in data.Rows)
                    {
                        writer.WriteStartRow();
                        foreach (object o in row.ItemArray)
                        {
                            writer.WriteExcelAutoStyledCell(o);
                        }
                        writer.WriteEndRow();
                    }
                    // Close up the document
                    writer.WriteEndWorksheet();
                    writer.WriteEndDocument();
                    writer.Close();
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
