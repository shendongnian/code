    [NotifyPropertyChanged]
    public class MyClass
    {
        public double SomeValue { get; set; }
    
        public double ModifiedValue { get; private set; }
    
        [NotifyPropertyChanged(AttributeExclude=True)]
        public double OnlySetOnce { get; private set; }
    
        public MyClass()
        {
            OnlySetOnce = 1.0;
        }
    }
