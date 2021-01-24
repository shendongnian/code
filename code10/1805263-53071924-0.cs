    DataSet result= reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true,
                                ReadHeaderRow = (rowReader) =>
                                {
                                   
                                }
                            }
                        });
