    public class MyClass : INotifyPropertyChanged
    {
        public event EventHandler OnAgeChanged;
    
        public int HeyAge
        {
            get => age;
            set
            {
                age = value;
                RaisePropertyChanged("HeyAge");
                OnAgeChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        ...
        ...
