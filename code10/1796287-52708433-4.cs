     DateTime t1 = DateTime.Now;
    //Image[] images = Array.ConvertAll(files2, file => Image.FromFile(file.FullName));
    Image[] images = loadImagesThreaded(files2);
    DateTime t2 = DateTime.Now;
    
    TimeSpan ts = t2.Subtract(t1);
    MessageBox.Show("Loading took: " + ts.Seconds + "s " + ts.Milliseconds + "ms"); //6s 414ms
    
    Resources.ProductImageList_256.Images.AddRange(images);
