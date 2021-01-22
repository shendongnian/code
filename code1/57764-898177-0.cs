    protected void Button1_Click(object sender, EventArgs e)
    {
         Response.ContentType = "text/csv";
         Response.AddHeader("content-disposition", "attachment; filename=download.csv");
         Response.Write("your,csv,file,contents");
         Response.End();
    }
