    using(StreamReader sr = new StreamReader(File.Open(path, FileMode.Open))) {
        XDocument galleries = XDocument.Load(sr);
        string id = "10C31804CEDB42693AADD760C854ABD";
        var query = (from gallery in galleries.Descendants("Galleries")
                                              .Descendants("Gallery")
                     where (string)gallery.Attribute("ID") == id
                     select gallery.Descendants("Images")
                                   .Descendants("Image")
                    ).SingleOrDefault();
        Random rg = new Random();
        var image = query.ToList().RandomItem(rg);
        Console.WriteLine(image.Attribute("Title"));
    }
