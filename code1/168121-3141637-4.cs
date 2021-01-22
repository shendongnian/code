    using (CustomDataContext myDC = new CustomDataContext)
    {
      DataLoadOptions dlo = new DataLoadOptions();
      dlo.LoadWith<Gallery>(g => g.GalleryImages);
      dlo.LoadWith<GalleryImage>(gi => gi.Image);
      myDC.LoadOptions = dlo;
    
      List<Gallery> result = myDC.Galleries.ToList();
    }
