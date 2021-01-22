    using ImageMagickNET;
    public void Test() {
            MagickNet.InitializeMagick();
            ImageMagickNET.Image img = new ImageMagickNET.Image("file.psd");
            img.Resize(new Geometry(100, 100, 0, 0, false, false);
            img.Write("newFile.png");
    }
