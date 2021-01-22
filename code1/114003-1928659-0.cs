    ObservableCollection<Meets> _MeetCollection =
                new ObservableCollection<Meets>();
      
        public ObservableCollection<Meets> MeetCollection
        { get { return _MeetCollection; } }
 
        public class Meets
        {
            public string Date { get; set; }
            public string Time { get; set; }
            public string Description { get; set; }
        }
