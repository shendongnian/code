    interface IControl<T> 
    {
        string ID{get;set;}
        T Value{get;set;}
    }
    class SomeControl : IControl<string>
    {
        public string ID{get;set}
        public string Value{get;set;}
    }
    class SomeOtherControl : IControl<int>
    {
        public string ID{get;set}
        public int Value{get;set;}
    }
