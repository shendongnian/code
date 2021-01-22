    //example data
        ExcelDS ds = new ExcelDS();
                    ds.Data.AddDataRow("somthing", "more", "here");
                    ds.Data.AddDataRow("somthing2", "more2", "here2");
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
