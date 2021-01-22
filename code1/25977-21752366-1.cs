    public void WriteTo(this Stream input, string file)
    {
        //your fav write method:
        using (var stream = File.Create(file))
        {
            input.CopyTo(stream);
        }
        //or
        using (var stream = new MemoryStream())
        {
            input.CopyTo(stream);
            File.WriteAllBytes(file, stream.ToArray());
        }
        //whatever that fits.
    }
