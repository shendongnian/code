    class A1 : INotifyPropertyChanged
    {
        private string _myProperty;
        private static Expression<Func<A1, string>> myProperty = _ => _.MyProperty;
    
        public string MyProperty
        {
            get { return _myProperty; }
            set
            {
                _myProperty = value;
                InvokePropertyChanged(myProperty);
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void InvokePropertyChanged<T>(Expression<Func<A1, T>> property)
        {
            PropertyChangedEventHandler Handler = PropertyChanged;
            if (Handler != null)
            {
                MemberExpression expression = (MemberExpression)property.Body;
                Handler(this, new PropertyChangedEventArgs(expression.Member.Name));
            }
        }
    }
