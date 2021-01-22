    using (CustomDataContext myDC = new CustomDataContext)
    {
      List<Gallery> result = myDC.Images
        .Where(i => i.Id = selectedImage.Id);
        .SelectMany(i => i.GalleryImages)
        .Select(gi => gi.Galleries)
        .ToList()
    }
