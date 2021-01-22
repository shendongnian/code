    class Program
    {
        static void Main(string[] args)
        {
            MJPEGStream stream = new MJPEGStream("http://146.176.65.10/axis-cgi/mjpg/video.cgi");
            stream.NewFrame += (sender, e) =>
            {
                e.Frame.Save("test.jpg", ImageFormat.Jpeg);
                Console.WriteLine("frame saved into test.jpg");
                // stop capturing frames
                ((MJPEGStream)sender).Stop();
            };
            // start capturing frames
            stream.Start();
            Console.ReadLine();
        }
    }
