    /// <exception cref="FileNotFoundException">Thrown when somepath isn't a real file.</exception>
    public void MyMethod2()
    {
        FileInfo fi = new FileInfo( somepath );
        if( !fi.Exists )
        {
            throw new FileNotFoundException("somepath doesn't exists")
        }
        // Maybe go on to check you have permissions to read from it.
        System.IO.File.Open(somepath...); // this may still throw FileNotFoundException though
    }
