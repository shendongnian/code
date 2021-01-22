     public IQueryable<ArtGalleryData.Image> GetImagesByImageGroup(int id)
        {
            return SqlDataContext.Image_ImageGroups
                .Where(iig => iig.ImageGroupID == id)
                .Join(
                SqlDataContext.Images,
                iig => iig.ImageID,
                i => i.ImageID,
                (iig, i) => new ArtGalleryData.Image 
                { ImageID = i.ImageID, 
                  Description = i.Description, 
                  Title = i.Title, 
                  Height = i.Height, 
                  Width = i.Width }).AsQueryable();
        }
