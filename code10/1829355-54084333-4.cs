    public class Item : INotifyPropertyChanged
    {
        public string ItemName { get; set; }
        int _count;
        public ICommand BtnClickPlusCommand { get; private set; }
        public ICommand BtnClickMinusCommand { get; private set; }
        public Item()
        {
            BtnClickPlusCommand = new Command(btnClickPlus);
            BtnClickMinusCommand = new Command(btnClickMinus);
        }
        void btnClickPlus()
        {
            Count = (++_count).ToString();
        }
        void btnClickMinus()
        {
            Count = (--_count).ToString();
        }
        public string Count 
        {
            get
            {
                return _count.ToString();
            }
            set
            {
                int j;
                if (Int32.TryParse(value, out j))
                {
                    _count = j;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
                }
                else
                    Console.WriteLine("value could not be parsed to int");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
