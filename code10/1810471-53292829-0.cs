    foreach (DataRow row in dt.Rows) // dt = my dataTable loaded with ExcelDataReader
                        {
                            using (AppContext context = new AppContext())
                            {
                                string date = row.ItemArray[4].ToString(); 
                                DateTime parseDate = DateTime.Parse(date); // I did a parse because the column "e" only accepted DateTime and not String types.
                                var existingRow = context.Data.FirstOrDefault(d => d.e == parseDate);
                                if (existingRow != null)
                                {
                                    Console.WriteLine("Do Nothing");
                                }
                                else
                                {
                                    Data datos = new Data
                                    {
                                        a = row.ItemArray[0].ToString(),
                                        b = row.ItemArray[1].ToString(),
                                        c = row.ItemArray[2].ToString(),
                                        d = row.ItemArray[3].ToString(),
                                        e = parseDate
                                    };
                                    context.Data.Add(datos);
                                    context.SaveChanges();
                                }
                            }
                        }
