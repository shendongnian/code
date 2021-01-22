        private void makeAvi(string imageInputfolderName, string outVideoFileName, float fps = 12.0f, string imgSearchPattern = "*.png")
        {   // reads all images in folder 
            VideoWriter w = new VideoWriter(outVideoFileName, 
                new Accord.Extensions.Size(480, 640), fps, true);
            Accord.Extensions.Imaging.ImageDirectoryReader ir = 
                new ImageDirectoryReader(imageInputfolderName, imgSearchPattern);
            while (ir.Position < ir.Length)
            {
                IImage i = ir.Read();
                w.Write(i);
            }
            w.Close();
        }
