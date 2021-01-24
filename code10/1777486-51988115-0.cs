    public class YourViewModel : INotifyPropertyChanged
    {
        public bool Condition1
        {
            get { //return _c1; or something }
            set
            {
                //_c1 = value or something
                //notify framework
                NotifyPropertyChanged(nameof(IsOtherThingEnabled))
            }
        }
        public bool Condition2
        {
            get { //return _c2; or something }
            set
            {
                //_c2 = value or something
                //notify framework
                NotifyPropertyChanged(nameof(IsOtherThingEnabled))
            }
        }
        public bool IsOtherThingEnabled
        {
            get
            {
                return _c1 && _c2; //or something
            }
        }
    }
