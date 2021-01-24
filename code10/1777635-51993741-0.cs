    foreach (string sourcefile in sourcefiles)
        {
            if (sourcefile.EndsWith(".jpeg"))
            {
                bool bSuccess = true;
                string destFile = Path.Combine(destinationPath, "2018 Picture" + "(" + counter + ")" + ".jpeg");
                counter = 0;
                while (File.Exists(destFile))
                {
                    destFile = Path.Combine(destinationPath, "2018 Picture" + "(" + counter + ")" + ".jpeg");
                    counter++;
                    if(counter>1000)
                    {
                        MessageBox.Show("'Too many tries.' or what ever message you want to use.");                        
                        bSuccess = false;;
                    }
                }
                if(bSuccess)
                {
                    MessageBox.Show(destFile);
                    File.Move(sourcefile, destFile);
                }
          }
