    static class Program
    {
        static int Main(string[] args)
        {
            // Maybe do some validation here
            string imgPath = args[0];
            // Create Method GetBinaryData to return the Image object you're looking for based on the path.
            Image img = GetBinaryData(imgPath);
            ShowImage(img);
        }
    }
