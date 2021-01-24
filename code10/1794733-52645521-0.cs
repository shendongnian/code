    //File containing only the value of the imagelist
    string source = @"C:\Users\fd\source\repos\Trials\WindowsFormsApp1\imagelistsource.txt";
                
    BinaryFormatter formatter = new BinaryFormatter();
    string base64 = File.ReadAllText(source);
    byte[] bytes = Convert.FromBase64String(base64);
    using (Stream stream = new MemoryStream(bytes))
    {
        ImageListStreamer streamer = (ImageListStreamer)formatter.Deserialize(stream);
        //streamer.ImageList is actually null BUT that does not matter at all.
        ImageList list = new ImageList();
        list.ImageStream = streamer;
        
        //list is now filled with all the images !
       foreach (Bitmap image in list.Images)
       {
           //Got my Bitmap YAY !             
       }
    }
