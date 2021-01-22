            Table<Gallery> galleries = pdc.GetTable<Gallery>();
            Table<GalleryImage> images = pdc.GetTable<GalleryImage>();
            Table<Comment> comments = pdc.GetTable<Comment>();
            var query = from gallery in galleries
                        join image in images on gallery.id equals image.galleryid into joinedimages
                        join comment in comments on gallery.id equals comment.galleryid into joinedcomments
                        select new
                        {
                            name = gallery.name,
                            wheretaken = gallery.wheretaken,
                            id = gallery.id,
                            GalleryImages = joinedimages,
                            Comments = joinedcomments.Take(3)
                        };
            gallst.DataSource = query;
            gallst.DataBind();
