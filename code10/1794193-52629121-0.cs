    for(int j = 0; j < streams.Count; j++)
    {
        using(streams[j])
        {
            using(var image = System.Drawing.Image.FromStream(streams[j]))
                image.Save();
        }
    }
