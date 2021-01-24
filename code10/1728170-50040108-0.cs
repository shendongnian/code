    public class AlbumListResponseModel
    {
     public IEnumerable<Album> Albums { get; set; }
    }
     public async Task<IActionResult> GetAlbums()
      {
        AlbumListResponseModel model = new AlbumListResponseModel
         {
             Albums = db.Albums;
         } 
        return OK(model);
      }
