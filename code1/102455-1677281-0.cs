             SPSecurity.RunWithElevatedPrivileges(() =>
             {
                 using (SPWeb thisWeb = site.OpenWeb(webUrl))
                 {  
                     thisWeb.AllowUnsafeUpdates = true;
    
                     if (!thisWeb.ValidateFormDigest())
                        throw new InvalidOperationException("Form Digest not valid");
                     
                     thisWeb.Title = newName;
                     thisWeb.Update();
                 }
              });
