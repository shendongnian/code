      IQueryable<AlbumEntity> query = context.Albums;
      if (someCondition)
      {
          query = query.Where(a => a.ReleaseYear.Equals(year));
      }
      if (someOtherCondition)
      {
          query = query.Where(a => a.Composer.Equals(composer));
      }    
      albumList = query.ToList();
