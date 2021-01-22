    public class Report
    {
        public List<Publication> Publications { get; set; }
        public int TotalPublicationsRead 
        {
            get 
            { 
                return this.Publications.Count(p => p.Read); 
            }
        }
        
    }
    public class Publication : INotifyPropertyChanged
    {
        private bool read;
        public bool Read
        {
            get { return this.read; }
            set { this.read = value; }
        }
    }
