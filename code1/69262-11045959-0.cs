        Add these Lines in Web.Config file
        --------------------------------------
        Normal file upload size is 4MB. Here Under system.web maxRequestLength mentioned in KB and in system.webServer maxAllowedContentLength as in Bytes.
        
        <system.web>
          .
          .
          .
          <httpRuntime executionTimeout="3600" maxRequestLength="102400" useFullyQualifiedRedirectUrl="false" delayNotificationTimeout="60"/>
        </system.web>
        
        
        <system.webServer>
          .
          .
          .
          <security>
              <requestFiltering>
                <requestLimits maxAllowedContentLength="1024000000" />
                <fileExtensions allowUnlisted="true"></fileExtensions>
              </requestFiltering>
            </security>
        </system.webServer>
        
        
        and if you want to know the maxFile upload size mentioned in web.config use the given line in .cs page
        
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
