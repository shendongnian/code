    MagickReadSettings settings = new MagickReadSettings();
    settings.ColorSpace = ColorSpace.sRGB;
    settings.Format = MagickFormat.Eps;
    settings.Compression = Compression.LosslessJPEG;
    settings.Density = new Density(300);
    using (MagickImage _image = new MagickImage())
    {
        _image.Read(image.Path, settings);
        _image.Write("teste.jpg");
    }
