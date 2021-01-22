    return from i in qry
           from it in i.ImageTags
           where tags.Select(t => t.ID).Contains(it.Tag.ID)
           group new { Image = i, it.Tag } by i.ID into g
           let tagCount = g.Count()
           orderby tagCount descending
           select g.First().Image;
