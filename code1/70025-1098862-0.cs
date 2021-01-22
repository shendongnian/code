        var imagesPerOrgan = organs.Select(organ => ImagesOrgans.Where(io => io.OrganId = organ.Id));
        var result = null;
        foreach (var item in imagesPerOrgan)
        {
            if (result == null)
            {
                result = item;
            }
            else
            {
                result = result.Intersect(result);
            }
        }
  
