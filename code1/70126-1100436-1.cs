    [ContentProperty(SomeProp)]
    class SomeClass
    {
        //this is where subitems created in xaml would get added automatically
        public IList<int> SomeProp { get; set; } 
    }
