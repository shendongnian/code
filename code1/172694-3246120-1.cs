      private void CreateShortcutInStartUP()
            {
                try
                {
                    Assembly code = Assembly.GetExecutingAssembly();
                    String company =  Application.CompanyName;
                    String ApplicationName = Application.ProductName;
    
                    if( company != "" && ApplicationName != "") 
                    {
                        String DesktopPath= Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + ApplicationName + @".appref-ms";
                        String ShortcutName= Environment.GetFolderPath(Environment.SpecialFolder.Programs) + @"\" + company + @"\" + ApplicationName + @".appref-ms";
                        if (System.IO.File.Exists(ShortcutName))
                            System.IO.File.Copy(ShortcutName, DesktopPath, true);
                        
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
