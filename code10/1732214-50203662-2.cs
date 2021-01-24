    public class PageNameViewModel
    {
        public string Name { get; set; }
        public IEnumerable<ResortDetailViewModel> ResortDetailViewModels { get; set; }
        ... rest of properties are not shown for clarity ...
    }
    public class ResortDetailViewModel
    {
        public string Detail1 { get; set; }
        public int Detail2 { get; set; }
        ... etc. ...
    }
