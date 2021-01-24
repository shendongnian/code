     string filePath = txt1.Text;
    if (filePath != "")
    {
        lblDownloadS1.Text = "File downloaded successfully please check in downloads";
        Response.Write("<script>alert('File downloaded succesfully')</script>");
        Response.ContentType = ContentType;
        Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
        Response.WriteFile(filePath);
        // try this --- Response.Write("<script>window.open('lblDownloadS1.Text'-blank');</script>");
        Response.End();
    }
    else
    {
      
        Response.Write("<script>alert(' Specified file not exist')</script>");
    }
                
