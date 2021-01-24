    Image[] images = new Image[files2.Count()];
    Parallel.ForEach(files2, (fileInfo, state, index) =>
    {
    	images[index] = Image.FromFile(fileInfo.FullName);
    });
    
    DateTime t2 = DateTime.Now;
    TimeSpan ts = t2.Subtract(t1);
    MessageBox.Show("Loading took: " + ts.Seconds + "s " + ts.Milliseconds + "ms");
