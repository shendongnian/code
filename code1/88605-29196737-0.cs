        private void Change_BackgroundImage(string _path)
      {
        string imagepath = _path;
        System.IO.FileStream fs;
     // MDI Form image background layout change her`enter code here`e     
     //(Remember control imagebakground layout take default form background layount )
              this.BackgroundImageLayout = ImageLayout.Center;
                // Checking File exists if yes go --->
                if (System.IO.File.Exists(imagepath))
                {
                  // Read Image file
                  fs = System.IO.File.OpenRead(imagepath);
                    fs.Position = 0;
                    // Change MDI From back ground picture
                    foreach (Control ctl in this.Controls)
                    {
                        if (ctl is MdiClient)
                        {
                          //ctl.BackColor = Color.AntiqueWhite;
                           ctl.BackColor = Color.FromArgb(31, 26, 23);
                           ctl.BackgroundImage = System.Drawing.Image.FromStream(fs);
                          break;
                           }
                      }
                 }
              }
