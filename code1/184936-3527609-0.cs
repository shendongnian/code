              try
                {
                    
                 // Set directory for list to be made of
                    DirectoryInfo jpegInfo = new DirectoryInfo(destinationFolder);
                    DirectoryInfo jpgInfo = new DirectoryInfo(destinationFolder);
                    DirectoryInfo gifInfo = new DirectoryInfo(destinationFolder);
                    DirectoryInfo tiffInfo = new DirectoryInfo(destinationFolder);
                    DirectoryInfo bmpInfo = new DirectoryInfo(destinationFolder);
                    // Set file type
                    FileInfo[] Jpegs = jpegInfo.GetFiles("*.jpeg");
                    FileInfo[] Jpgs = jpegInfo.GetFiles("*.jpg");
                    FileInfo[] Gifs = gifInfo.GetFiles("*.gif");
                    FileInfo[] Tiffs = gifInfo.GetFiles("*.tiff");
                    FileInfo[] Bmps = gifInfo.GetFiles("*.bmp");
                    
            //  listBox1.Items.Add(@"");  // Hack for the first list item no preview problem
            // Iterate through each file, displaying only the name inside the listbox...
            foreach (FileInfo file in Jpegs)
            {
                    listBox1.Items.Add(file.Name);
                    Photo curPhoto = new Photo();
                    curPhoto.PhotoLocation = file.FullName;
                    metaData.AddPhoto(curPhoto);
                }
              foreach (FileInfo file in Jpgs)
              {
                  listBox1.Items.Add(file.Name);
                    Photo curPhoto = new Photo();
                    curPhoto.PhotoLocation = file.FullName;
                    metaData.AddPhoto(curPhoto);
                }
              foreach (FileInfo file in Gifs)
              {
                  listBox1.Items.Add(file.Name);
                  Photo curPhoto = new Photo();
                  curPhoto.PhotoLocation = file.FullName;
                  metaData.AddPhoto(curPhoto);
              }
              foreach (FileInfo file in Tiffs)
              {
                  listBox1.Items.Add(file.Name);
                  Photo curPhoto = new Photo();
                  curPhoto.PhotoLocation = file.FullName;
                  metaData.AddPhoto(curPhoto);
              }
              foreach (FileInfo file in Bmps)
              {
                  listBox1.Items.Add(file.Name);
                  Photo curPhoto = new Photo();
                  curPhoto.PhotoLocation = file.FullName;
                  metaData.AddPhoto(curPhoto);
              }
