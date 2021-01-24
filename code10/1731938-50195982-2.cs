    public class RailwaySignal
    {
    
        private List<RailwayUser> _watches;
    
        public Colour Stata { get; set; }
    
        public RailwaySignal()
        {
            _watches = new List<RailwayUser>();
        }
    
        public void SubScript(RailwayUser user)
        {
            _watches.Add(user);
        }
    
        public void Notify()
        {
            foreach (RailwayUser u in _watches)
            {
                u.PrintClassName();
                u.Notice(Stata);
            }
        }
    }
