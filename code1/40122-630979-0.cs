    class MyClass
    {
        public SomeEnum E { get; set; }
        // This might be better as : public Object GetTheObject(SomeEnum E) and eliminating the above property
        public Object GetTheObject()
        {
             switch(this.E)
             {
             case E.Something:
                return new MySomethingObject(); // Or return an instance that already exists...?
             default:
                return new MyDefaultObject();
             }
        }
    }
