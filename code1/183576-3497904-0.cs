    protected void Page_Load(object sender, EventArgs e)
    {
        Response.WriteFile(@"C:\myFile", false);
        System.IO.File.Move(@"C:\myFile", "C:\myFile2");
        Response.End();
    }
