    //Create the image control
    Image img = new Image {HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch, VerticalAlignment = System.Windows.VerticalAlignment.Stretch};
    //Create a seperate thread to load the image
    ThreadStart thread = delegate
         {
             //Load the image in a seperate thread
             BitmapImage bmpImage = new BitmapImage();
             MemoryStream ms = new MemoryStream();
             //A custom class that reads the bytes of off the HD and shoves them into the MemoryStream. You could just replace the MemoryStream with something like this: FileStream fs = File.Open(@"C:\ImageFileName.jpg", FileMode.Open);
             MediaCoder.MediaDecoder.DecodeMediaWithStream(ImageItem, true, ms);
             bmpImage.BeginInit();
             bmpImage.StreamSource = ms;
             bmpImage.EndInit();
             //**THIS LINE locks the BitmapImage so that it can be transported across threads!! 
             bmpImage.Freeze();
             //Call the UI thread using the Dispatcher to update the Image control
             Dispatcher.BeginInvoke(new ThreadStart(delegate
                     {
                             img.Source = bmpImage;
                             img.Unloaded += delegate 
                                     {
                                             ms.Close();
                                             ms.Dispose();
                                     };
                              grdImageContainer.Children.Add(img);
                      }));
         };
    //Start previously mentioned thread...
    new Thread(thread).Start();
