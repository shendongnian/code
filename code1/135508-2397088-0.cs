    public class EditSongViewModel
    {        
        public string Title { get; set; }                
        public int TrackNumber { get; set; }
        public IEnumerable<SelectListItem> Albums { get; set; }
    }
