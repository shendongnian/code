    Image myImage = new System.Drawing.Image();
    Imaging.Encoder enc = new System.Drawing.Imaging.Encoder();
    Imaging.EncoderParameter param = new 
    Imaging.EncoderParameter();
    Imaging.EncoderParameters parameters = new 
    Imaging.EncoderParameters(1);
    
    parameters.Param[0] = param;
    myImage.Save(somestream, enc, parameters);
