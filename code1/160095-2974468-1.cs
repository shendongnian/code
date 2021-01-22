    public void CombineIntoTiff(string outputTiff, params string[] inputFiles)
    {
        using (FileStream stm = new FileStream(outputTiff, FileMode.Create)) {
            TiffEncoder enc = new TiffEncoder();
            enc.Compression = TiffCompression.JpegCompression;
            enc.Append = true;
            foreach (string file in inputFiles) {
                AtalaImage image = null;
                try { image = new AtalaImage(file); } catch { continue; }
                enc.Save(image);
            }
        }
    }
