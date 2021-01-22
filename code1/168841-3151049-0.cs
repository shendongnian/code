    byte[] data = new byte[1024];
    string path = System.IO.Path.GetTempFileName();
    int bytesPerSecond = 0;
    using (System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Create))
    {
        System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
        watch.Start();
        for (int i = 0; i < 1024; i++) fs.Write(data, 0, data.Length);
        fs.Flush();
        watch.Stop();
        bytesPerSecond = (int)((data.Length * 1024) / watch.Elapsed.TotalSeconds);
    }
    System.IO.File.Delete(path);
