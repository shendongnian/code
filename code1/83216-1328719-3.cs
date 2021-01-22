    DataSet dsExcelContent = new DataSet();
                //Fill from db
                //
                foreach (DataRow row in dsExcelContent.Tables[0])
                {
                    StringBuilder builder = new StringBuilder();
                    foreach (DataColumn col in dsExcelContent.Tables[0].Columns)
                    {
                        builder.Append(row[col].ToString());
                        builder.Append(" ");
                    }
                    Console.WriteLine(builder.ToString());
                }
