    //example data
        ExcelDS ds = new ExcelDS();
                    ds.Data.AddDataRow("1", "2", "3");
                    ds.Data.AddDataRow("4", "5", "6");
    //end of example data
                    foreach (ExcelDS.DataRow row in ds.Data)
                    {
                        StringBuilder builder = new StringBuilder();
                        foreach (DataColumn col in ds.Data.Columns)
                        {
                            builder.Append(row[col].ToString());
                            builder.Append(" ");
                        }
                        //do something with string....
                        Console.WriteLine(builder.ToString());
                    }
