    static void Main(string[] args)
    {
            var list = ImageCodecInfo.GetImageDecoders();
            var jpegEncoder = list[1]; // i know this is the jpeg encoder by inspection
            Bitmap bitmap = new Bitmap(500, 500);
            Graphics g = Graphics.FromImage(bitmap);
            g.DrawRectangle(new Pen(Color.Red), 10, 10, 300, 300);
            var encoderParams = new EncoderParameters();
            encoderParams.Param[0] = new EncoderParameter(Encoder.ColorDepth, 2);
            bitmap.Save(@"c:\newbitmap.jpeg", jpegEncoder, encoderParams);
    }
