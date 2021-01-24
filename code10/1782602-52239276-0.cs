        public class ZipItem
        {
            public StorageFile motherfile { get; set; }  //Source File
            public ZipArchiveEntry motherentry { get; set; }  /Compressed file within the source file
            public string Name { get; set; }
            public string ActualBytes { get; set; }
            public string CompressedBytes { get; set; }
        }
        public List<ZipItem> results;      //List of all ZipItems (all elements of a Zipfile, for manipulation purposes)
        public int numfiles = 0;   // Total number of files 
        public int i = 0;   //Pointer to the current element in the list (for slideshow purposes)
        private async void  nextimg_Click(object sender, RoutedEventArgs e)
        {
            Stream stream = await results[i].motherfile.OpenStreamForReadAsync(); //Create a stream... I know this is the wrong type (see error below)
            ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Update);  //Open the ZipArchive. This gives me an error telling me that "Update mode requires a stream with Read, Write and Seek permission.
            ZipArchiveEntry entry = results[i].motherentry; //This is where I'm stuck.... how do I tell it to open a specific entry in the zip file?
            using (var fileStream = entry.Open()) //How do I open it as an IRandomAccessStream?
            //using (IRandomAccessStream fileStream = results[i].motherentry.Open());
            {
               
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.DecodePixelHeight = (int)ctlImage.Height;
                bitmapImage.DecodePixelWidth = (int)ctlImage.Width;
                bitmapImage.SetSource(filestream); //I know I need a IRandomAccessStream
                ctlImage.Source = bitmapImage;   //Hopefully display the image... 
                
            }
        }
