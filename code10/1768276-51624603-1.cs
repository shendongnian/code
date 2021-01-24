    public class EventManager : INotifyPropertyChanged
    {
        public List<Event> events { get; set; }
        public List<People> peoples { get; set; }
        //this is the current event that correspond to the selected event in your combobox
        private Event _currentEvent;
        public Event currentEvent
        {
            get
            {
                return _currentEvent;
            }
            set
            {
                if (_currentEvent != value)
                {
                    _currentEvent = value;
                    //when you change the selected event, you have to update the list of participants
                    OnPropertyChanged("participants");
                }
            }
        }
        public List<People> participants
        {
            get
            {
                //Here is the code to retrieve the people that registered to the selected event
                return peoples.Where(p => p.registeredEvents.Contains(currentEvent)).ToList<People>();
            }
        }
        public EventManager()
        {
            events = new List<Event>();
            peoples = new List<People>();
        }
        //The following lines are specific to WPF and DataBinding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
