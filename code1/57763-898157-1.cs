    public void btnGo_Click (Object sender, EventArgs e)
    {
        Response.Clear();
        string fileName= String.Format("data-{0}.csv", DateTime.Now.ToString("yyyy-MMM-dd-HHmmss")); 
        Response.ContentType = "text/csv";
        Response.AddHeader("content-disposition", "filename=" + fileName);
        // write string data to Response.OutputStream here
        Response.Write("aaa,bbb,ccc\n");
        Response.End();
    }
