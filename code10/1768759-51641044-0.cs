    class MyClass
    {
        public MyClass(IService service)
        { 
            this.Service = service;
        }
        public MyClass() : this(new Service())
        {
        }
    }
