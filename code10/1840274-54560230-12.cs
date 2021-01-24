    class MyItem : ObservableObject
    {
        public int Value { get; }
        
        [DependsOn(nameof(Value))]
        public int DependentValue { get; }
    }
