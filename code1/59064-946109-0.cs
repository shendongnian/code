    public disposable class MyClass
    {
        readonly AnotherDisposableObject resource = new AnotherDisposableObject();
        ~MyClass()
        {
            this.resource.Dispose();
        }
        public void DoStuff()
        {
            this.resource.SomeMethod();
        }
    }
