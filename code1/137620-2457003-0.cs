    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            var o1 =
                Observable.FromEvent<PropertyChangedEventArgs>(this, "PropertyChanged");
            o1.Subscribe(e => Debug.WriteLine(e.EventArgs.PropertyName));
            var o2 = o1.SkipWhile(e => e.EventArgs.PropertyName != "Property1");
            var o3 = o1.SkipWhile(e => e.EventArgs.PropertyName != "Property2");
            var o4 = o1.SkipWhile(e => e.EventArgs.PropertyName != "Result");
            var o5 = Observable.CombineLatest(o2, o3, (e1, e2) => DoStuff()).TakeUntil(o4);
            o5.Subscribe(o => Debug.WriteLine("Got Prop1 and Prop2"));
        }
        public string DoStuff()
        {
            return Result = string.Concat(Property1, Property2);                
        }
        private string _property1;
        public string Property1
        {
            get { return _property1; }
            set
            {
                _property1 = value;
                OnNotifyPropertyChanged("Property1");
            }
        }
        private string _property2;
        public string Property2
        {
            get { return _property2; }
            set
            {
                _property2 = value;
                OnNotifyPropertyChanged("Property2");
            }
        }
        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnNotifyPropertyChanged("Result");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotifyPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
