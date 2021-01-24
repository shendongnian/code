    private async Task btn_AddImg_ClickedAsync(object sender, EventArgs e)
            {
                var file = await CrossFilePicker.Current.PickFileAsync();
                if (file != null)
                {
                    Error.IsVisible = true;
                    Error.Text = file.FilePath;
    
                    var dirToCreate = Path.Combine(Android.App.Application.Context.FilesDir.AbsolutePath, "WightLossPersonal");
                    if (!Directory.Exists(dirToCreate))
                    {
                          Directory.CreateDirectory(dirToCreate);
                       // var x= Directory.CreateDirectory(dirToCreate); // don't need that variable x here since you don't want to use it later
                        //System.IO.File.Copy(file.FilePath, dirToCreate, true); No need here, will copy it in all ways down .
    
                    }
                    //else   // you don't need else, copy the file when finishing the check.
                    //{
                      // Make a new path to compine the dir and the fileName
                       string destFolder = Path.Combine(dirToCreate, file.Name);
                       System.IO.File.Copy(file.FilePath, destFolder , true);
                    //}
    
                }
      
      }
