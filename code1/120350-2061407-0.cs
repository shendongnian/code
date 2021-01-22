    XElement GetRandomImage(XElement images)
    {
        Random rng = new Random();
        int numberOfImages = images.Elements("Image").Count();
        return numberOfImages == 0 :
            null ?
            images.Elements("Image").Skip(rng.Next(0, numberOfImages)).First();
    }
    XElement GetRandomImage(XElement images)
    {
        Random rng = new Random();
        IList<XElement> images = images.Elements("Image").ToList();
        return images.Count == 0 :
            null ?
            images[rng.Next(0, images.Count)];
    }
