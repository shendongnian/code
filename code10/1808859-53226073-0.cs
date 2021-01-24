    public class ParentViewModel
    {
        public ParentViewModel()
        {
            PartialViewModel1 = new PartialViewModel1();
            PartialViewModel2 = new PartialViewModel2();
            PartialViewModel3 = new PartialViewModel3();
        }
    
        public string PartialViewType { get; set; } /* Value to determine which view to show */
        public PartialViewModel1 PartialViewModel1 { get; set; }
        public PartialViewModel2 PartialViewModel2 { get; set; }
        public PartialViewModel3 PartialViewModel3 { get; set; }
    }
