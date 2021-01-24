    public class Dog : INotifyPropertyChanged
    {
        private string _name;
        private string _number;
        public string Name { get { return _name; } }
        public string Number { get { return _number; } }
        public Dog(string name, int number)
        {
            _name = name;
            _number = number.ToString("D4");
        }
