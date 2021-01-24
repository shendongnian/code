    class MyClass : ObservableObject
    {
        private int val;
        public int Val
        {
            get => val;
            set => SetField(ref val, value);
        }
        // MyChildClass must implement INotifyPropertyChanged
        private MyChildClass child;
        public MyChildClass Child
        {
            get => child;
            set => SetField(ref child, value);
        }
        [DependsOn(typeof(MyChildClass), nameof(MyChildClass.MyProperty))]
        [DependsOn(nameof(Val))]
        public int Sum => Child.MyProperty + Val;
    }
