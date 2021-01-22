    protected void Button1_Click(object sender, EventArgs e)
    {
      if (this.FileUpload1.HasFile)
      {
        this.FileUpload1.SaveAs("c:\\" + this.FileUpload1.FileName);
      }
    }
