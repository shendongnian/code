    public void Export(List<DataType> list)
    {
        StringWriter sw = new StringWriter();
        //First line for column names
        sw.WriteLine("ID,Date,Description");
        foreach(DataType item in list)
        {
            sw.WriteLine(string.format("{0},{1},{2}",
                                       item.ID,
                                       item.Date,
                                       item.Description));
        }
   
        Response.AddHeader("Content-Disposition", "attachment; filename=test.csv");
        Response.ContentType = "text/csv";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.Write(sw);
        Response.End(); 
    }
