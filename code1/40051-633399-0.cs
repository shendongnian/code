    protected void Page_Load(object sender, EventArgs e)
    {
      byte[] jpg = .....
      Response.Clear();
      Response.ContentType = "image/jpeg";
      Response.BinaryWrite(jpg);
      Response.End();
    }
