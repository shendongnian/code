    class MyClass
    {
        int Value1 { get; set; }
        float Value2 { get; set; }
        
        public MyClass Copy()
        {
            var copy = new MyClass()
                           {
                               Value1 = this.Value1,
                               Value2 = this.Value2
                           }
            return copy;
        }
    }
