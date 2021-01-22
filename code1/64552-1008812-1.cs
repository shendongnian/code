    protected void streamToResponse()
    {
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=testfile.csv");
        Response.AddHeader("content-type", "text/csv");
        using(StreamWriter writer = new StreamWriter(Response.OutputStream))
        {
            writer.WriteLine("col1,col2,col3");
            writer.WriteLine("1,2,3");
        }
        Response.End();
    }
