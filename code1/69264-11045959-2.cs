        System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
        HttpRuntimeSection section = config.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
       
         //get Max upload size in MB                 
         double maxFileSize = Math.Round(section.MaxRequestLength / 1024.0, 1);
         //get File size in MB
         double fileSize = (FU_ReplyMail.PostedFile.ContentLength / 1024) / 1024.0;
    
         if (fileSize > 25.0)
         {
              ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", "alert('File Size Exceeded than 25 MB.');", true);
              return;
         }
