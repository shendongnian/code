     string filePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "").Replace("\\bin\\Release", "");
                    string fileLocation = filePath + ConfigurationManager.AppSettings["EmployeeDetailsFilePath"];
                    Stream inputStream = File.Open(fileLocation, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateOpenXmlReader(inputStream);
                    reader.IsFirstRowAsColumnNames = true;
                    DataSet dataSet = reader.AsDataSet();
                    inputStream.Dispose();
                    reader.Dispose();
