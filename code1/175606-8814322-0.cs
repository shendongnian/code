    /// <summary>
    /// Loads every image from the folder specified as param.
    /// </summary>
    /// <param name="pDirectory">Path to the directory from which you want to load images.  
    /// NOTE: this method will throws exceptions if the argument causes 
    /// <code>Directory.GetFiles(path)</code> to throw an exception.</param>
    /// <returns>An ImageList, if no files are found, it'll be empty (not null).</returns>
    public static ImageList InitImageListFromDirectory(string pDirectory)
    {
        ImageList imageList = new ImageList();
        
        foreach (string f in System.IO.Directory.GetFiles(pDirectory))
        {
            try
            {
                Image img = Image.FromFile(f);
                imageList.Images.Add(img);
            }
            catch
            {
                // Out of Memory Exceptions are thrown in Image.FromFile if you pass in a non-image file.
            }
        }
        return imageList;
    }
