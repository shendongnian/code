    Image i = System.Drawing.Image.FromFile("wut.jpg");
    Stream stm = new Stream();
    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
    System.Drawing.Imaging.EncoderParameters paramz = new System.Drawing.Imaging.EncoderParameters(1);
    myEncoderParameter = new EncoderParameter(myEncoder, 100L);
    paramz.Param[0] = myEncoderParameter;
    i.Save(stm, System.Drawing.Imaging.ImageFormat.Jpeg, paramz);
    /* I'm lazy: code for reading Stream into byte[] here */
