     protected void lnbDownloadFile_Click(object sender, EventArgs e)
     {
      String YourFilepath;
      System.IO.FileInfo file = 
      new System.IO.FileInfo(YourFilepath); // full file path on disk
      Response.ClearContent(); // neded to clear previous (if any) written content
      Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
      Response.AddHeader("Content-Length", file.Length.ToString());
      Response.ContentType = "text/plain";
      Response.TransmitFile(file.FullName);
      Response.End();
     }
