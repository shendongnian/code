    int GalID = 1;
    GalleryDataConext dc = new GalleryDataConext()
    var pics = from g in dc.Gallary
               join gi in dc.GallaryImages on g.Id equals gi.GallaryId
               join i in dc.Images on gi.ImageId equals i.Id
               where g.Id = GalID
               select i;
