    public class YourViewModel : INotifyPropertyChanged
    {
        private bool _c1, _c2;
        public bool Condition1
        {
            get { return _c1; }
            set
            {
                _c1 = value;
                //notify framework
                NotifyPropertyChanged(nameof(IsOtherThingEnabled))
            }
        }
        public bool Condition2
        {
            get { return _c2; }
            set
            {
                _c2 = value;
                //notify framework
                NotifyPropertyChanged(nameof(IsOtherThingEnabled))
            }
        }
        public bool IsOtherThingEnabled
        {
            get
            {
                return _c1 && _c2; 
            }
        }
        //etc.
    }
