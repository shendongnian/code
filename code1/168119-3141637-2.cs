    using (CustomDataContext myDC = new CustomDataContext)
    {
      List<Image> result = myDC.Galleries
        .Where(g => g.Id = selectedGallery.Id);
        .SelectMany(g => g.GalleryImages)
        .Select(gi => gi.Image)
        .ToList()
    }
