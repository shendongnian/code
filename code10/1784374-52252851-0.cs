    public class AAMMViewModel
    {
        public List<Actors> actz { get; set; }
        public List<Movies> mvz { get; set; }
        public AAMMViewModel()
        {
            actz = new List<Actors>();
            mvz = new List<Movies>();
        }
    }
    
    var act = (from i in _context.actz
                       join j in _context.mvz ON i.Id == j.Id
                       select i).ToList();
