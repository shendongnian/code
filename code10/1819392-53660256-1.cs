    [NonNullTypes(true)]
    class C
    {
        string NotNullProperty { get; set; }
    
        [Nullable]
        string NullProperty { get; set; }
    
        void M(string notNullParameter, [Nullable] string nullParameter) { }
    }
