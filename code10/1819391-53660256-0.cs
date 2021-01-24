    class C
    {
        string NotNullProperty { get; set; }
        string? NullProperty { get; set; }
        
        void M(string notNullParameter, string? nullParameter) {}
    }
