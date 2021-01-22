    using System;
    
    static void Main(string[] args)
    {
        MagickNet.Magick.Init();
        MagicNet.Image img = new MagicNet.Image("file.psd");
        img.Resize(System.Drawing.Size(100,100));
        img.Write("newFile.png");
        MagickNet.Magick.Term();
    }
