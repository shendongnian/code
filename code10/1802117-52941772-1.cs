    class MyClass
    {
        MyClass2 Reference { get; set; }
        
        public MyClass Copy()
        {
            var copy = new MyClass()
                           {
                               Reference = this.Reference.Copy()
                           }
            return copy;
        }
    }
