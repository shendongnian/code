     public static DataTable jsonStringToTable(string jsonContent)
     {
           DataTable dt = JsonConvert.DeserializeObject<DataTable>(jsonContent);
           return dt;
     }
     public static string jsonToCSV(string jsonContent, string delimiter)
     {
            StringWriter csvString = new StringWriter();
            using (var csv = new CsvWriter(csvString))
            {
              
                csv.Configuration.Delimiter = delimiter;
                using (var dt = jsonStringToTable(jsonContent))
                {
                  
                    foreach (DataColumn column in dt.Columns)
                    {
                        csv.WriteField(column.ColumnName);
                    }
                    csv.NextRecord();
                    foreach (DataRow row in dt.Rows)
                    {
                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            csv.WriteField(row[i]);
                        }
                        csv.NextRecord();
                    }
                }
            }
            return csvString.ToString();
        }
      public static string StreamToString(Stream stream)
      {
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            return text;
      }
      public static Stream StringtoStream(string str)
      {
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            MemoryStream stream = new MemoryStream(byteArray);
            return stream;
      }
