         private static void OpenExcelFile(string Path)
        {
            dynamic excelApp;
            excelApp = AutomationFactory.CreateObject("Excel.Application");
            dynamic workbook = excelApp.workbooks;
            object oMissing = Missing.Value;
            workbook = excelApp.Workbooks.Open(Path,
               oMissing, oMissing, oMissing, oMissing, oMissing,
               oMissing, oMissing, oMissing, oMissing, oMissing,
               oMissing, oMissing, oMissing, oMissing);
            dynamic sheet = excelApp.ActiveSheet;
            // open the existing sheet
          
            sheet.Cells.EntireColumn.AutoFit();
            excelApp.Visible = true;
        }
        private static string FormatCSVField(string data)
        {
            return String.Format("\"{0}\"",
                data.Replace("\"", "\"\"\"")
                .Replace("\n", "")
                .Replace("\r", "")
                );
        }
       public  static string ExportDataGrid(DataGrid grid,string SaveFileName,bool AutoOpen)
        {
            string colPath;
            System.Reflection.PropertyInfo propInfo;
            System.Windows.Data.Binding binding;
            System.Text.StringBuilder strBuilder = new System.Text.StringBuilder();
           var source = grid.ItemsSource;
           
            if (source == null)
                return "";
            List<string> headers = new List<string>();
            grid.Columns.ToList().ForEach(col =>
            {
                if (col is DataGridBoundColumn)
                {
                    headers.Add(FormatCSVField(col.Header.ToString()));
                }
            });
            strBuilder
            .Append(String.Join(",", headers.ToArray()))
            .Append("\r\n");
            foreach (var data in source)
            {
                    List<string> csvRow = new List<string>();
                    foreach (DataGridColumn col in grid.Columns)
                    {
                        if (col is DataGridBoundColumn)
                        {
                            binding = (col as DataGridBoundColumn).Binding;
                            colPath = binding.Path.Path;
                            propInfo = data.GetType().GetProperty(colPath);
                            if (propInfo != null)
                            {
                                string valueConverted = "";
                                if (binding.Converter.GetType().ToString() != "System.Windows.Controls.DataGridValueConverter")
                                    valueConverted = binding.Converter.Convert(propInfo.GetValue(data, null), typeof(System.String), binding.ConverterParameter, System.Globalization.CultureInfo.CurrentCulture).ToString();
                                else
                                    valueConverted = FormatCSVField(propInfo.GetValue(data, null) == null ? "" : propInfo.GetValue(data, null).ToString());
                                csvRow.Add(valueConverted.ToString());
                            }
                        }
                    }
                    strBuilder
                        .Append(String.Join(",", csvRow.ToArray()))
                        .Append("\r\n");
                }
            if (AutomationFactory.IsAvailable)
            {
                var sampleFile = "\\" + SaveFileName;
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path += "\\Pement";
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                else
                {
                    var files = System.IO.Directory.EnumerateFiles(path);
                    foreach (var item in files)
                    {
                        try
                        {
                            System.IO.File.Delete(item);
                        }
                        catch { }
                    }
                }
                StreamWriter sw = File.CreateText(path + sampleFile);
                sw.WriteLine(strBuilder.ToString());
                sw.Close();
                if (AutoOpen)
                    OpenExcelFile(path + sampleFile, true, true);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog()
                {
                    DefaultExt = "csv",
                    Filter = "CSV Files (*.csv)|*.csv|All files (*.*)|*.*",
                    FilterIndex = 1
                };
                if (sfd.ShowDialog() == true)
                {
                    using (Stream stream = sfd.OpenFile())
                    {
                        using (StreamWriter writer = new StreamWriter(stream))
                        {
                            writer.Write(strBuilder.ToString());
                            writer.Close();
                        }
                        stream.Close();
                    }
                } 
            }
            return strBuilder.ToString();
        }
