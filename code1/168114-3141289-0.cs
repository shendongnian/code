    DataConext dc = new GalleryDataConext();
    foreach (Gallery g in dc.Gallerys)
    {
      Console.Writeline("gallery id " + g.Id.ToString());
      foreach(GalleryImage gi in g.GalleryImages)
       {
          Console.Writeline("galleryimage id " + gi.Id.ToString());
          foreach(Image i in gi)
           {
             Console.Writeline("image id " + i.Id.ToString());
           }
       }
