                    using (TextFieldParser parser = new TextFieldParser(outputLocation))
                     {
                            parser.TextFieldType = FieldType.Delimited;
                            parser.SetDelimiters(",");
                            string[] headers = parser.ReadLine().Split(',');
                            foreach (string header in headers)
                            {
                                dataTable.Columns.Add(header);
                            }
                            while (!parser.EndOfData)
                            {
                                string[] fields = parser.ReadFields();
                                DataRow dr = dataTable.NewRow();
                                int i = 0;
                                foreach (var field in fields)
                                {
                                    dr[i] = field;
                                    i++;
                                }
                                dataTable.Rows.Add(dr);
                            }
                        }
