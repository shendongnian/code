    public class EditSongViewModel
    {        
        public int AlbumId { get; set; }
        public string Title { get; set; }                
        public int TrackNumber { get; set; }
        public IEnumerable<SelectListItem> Albums { get; set; }
    }
