    var images = Directory.EnumerateFiles(@"C:\test\adobe\rio", "*.png", SearchOption.TopDirectoryOnly).Select(x => new Mat(x)).ToArray();
    using(var stitcher = new Stitcher(false))
    {
        using (var vm = new VectorOfMat(images))
        {
            var result = new Mat();
            stitcher.Stitch(vm, result);
            result.Bitmap.Save(@"C:\test\adobe\rio_stitched.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            result.Dispose();
        }
    }
    foreach (var image in images) { image.Dispose(); }
  
