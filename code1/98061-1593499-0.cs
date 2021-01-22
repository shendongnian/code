    interface IFoo { }
    
    [Serializable]
    class CFoo : IFoo   { }
    
    [Serializable]
    class Bar
    {
        public IFoo Foo { get; set; }
    }
