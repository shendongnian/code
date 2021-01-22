    class One : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        int _first = 1;
        int _second = 2;
        public int First { get { return _first; }
                           set { _first = value; OnPropertyChanged("First"); } }
        public int Second { get { return _second; }
                            set { _second = value; OnPropertyChanged("Second"); } }
    }
    class Two : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        string _third = "Third";
        string _fourth = "Fourth";
        public string Third { get { return _third; }
                              set { _third = value; OnPropertyChanged("Third"); } }
        public string Fourth { get { return _fourth; }
                               set { _fourth = value; OnPropertyChanged("Fourth"); } }
    }
    class Comp : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        int _int1 = 100;
        One _part1 = new One();
        Two _part2 = new Two();
        public One Part1 { get { return _part1; }
                           set { _part1 = value; OnPropertyChanged("Part1"); } }
        public Two Part2 { get { return _part2; }
                           set { _part2 = value; OnPropertyChanged("Part2"); } }
        public int Int1 { get { return _int1; }
                          set { _int1 = value; OnPropertyChanged("Int1"); } }
    }
