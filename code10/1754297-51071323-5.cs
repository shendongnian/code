    namespace DPSCalculatorPrototype
    {
        public class Calculator : NotifyPropertyChanged
        {
            private string _damage;
    
            public string Damage
            {
                get { return _damage; }
    
                set
                {
                    _damage = value;
                    RaisePropertyChange("Damage");
                }
            }
        }
    
        public class NotifyPropertyChanged : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void RaisePropertyChange(string propertyName)
            {
                PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
            }
        }
    }
