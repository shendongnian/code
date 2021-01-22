    public static IEnumerable<SelectListItem> ToSelectListItems(
                  this IEnumerable<Album> albums, int selectedId)
    {
        return 
            albums.OrderBy(album => album.Name)
                  .Select(album => 
                      new SelectListItem
                      {
                        Selected = (album.ID == selectedId),
                        Text = album.Name,
                        Value = album.ID.ToString()
                       });
    }
