    // Since we're not using unmanaged resources anymore, explicitly disposing 
    // the Image only results in more immediate garbage collection, there wouldn't 
    // actually be a memory leak if you forget to dispose.
    if (pic.Image != null)
    {
        pic.Image.Dispose();
    }
    pic.Image = bmp;
