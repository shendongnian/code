    ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
    System.Drawing.Imaging.Encoder myEncoder =  System.Drawing.Imaging.Encoder.Quality;
    EncoderParameters myEncoderParameters = new EncoderParameters(1);
    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 100L);
    myEncoderParameters.Param[0] = myEncoderParameter;
    Bitmap orig = new Bitmap(@imageor); // imageor is the complete path of the original image
    
    Bitmap clone = new Bitmap(orig.Width, orig.Height,
    System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
    using (Graphics gr = Graphics.FromImage(clone))
    {
         gr.DrawImage(orig, new Rectangle(0, 0, clone.Width, clone.Height));
    }
    clone.Save(clonergb, jpgEncoder, myEncoderParameters); // clonergb is the complete path of the cloned jpeg RGB image
