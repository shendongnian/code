            ImageList galleryList = new ImageList();
            string[] GalleryArray = System.IO.Directory.GetFiles(txtSourceDir.Text);    //create array of files in directory
            galleryList.ImageSize = new Size(96, 64);
            for (int i = 0; i < GalleryArray.Length; i++)
            {
                if (GalleryArray[i].Contains(".jpg"))   //test if the file is an image
                {
                    var tempImage = Image.FromFile(GalleryArray[i]); //Load the image from directory location
                    Bitmap pic = new Bitmap(96, 64);
                    using (Graphics g = Graphics.FromImage(pic))
                    {
                        g.DrawImage(tempImage, new Rectangle(0, 0, pic.Width, pic.Height)); //redraw smaller image
                    }
                    galleryList.Images.Add(pic);    //add new image to imageList
                    tempImage.Dispose();    //after adding to the list, dispose image out of memory
                }
                
            }
            lstGallery.View = View.LargeIcon;  
            lstGallery.LargeImageList = galleryList;    //set imageList to listView
            for (int i = 0; i < galleryList.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                lstGallery.Items.Add(item); //add images in sequential order
            }
