    public class Dog : INotifyPropertyChanged
    {
        private string _name;
        private string _number;
        public Dog(string name, int number)
        {
            Name = name;
            Number = number.ToString("D4");
        }
        public String Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }
        public String Number
        {
            get { return _number; }
            set
            {
                if (value != _number)
                {
                    _number = value;
                    NotifyPropertyChanged(nameof(Number));
                }
            }
        }
