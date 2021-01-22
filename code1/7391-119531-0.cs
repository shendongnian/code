    class Parent
    {
        public Parent()
        {
            DoSomething();
        }
        protected virtual void DoSomething() {};
    }
    class Child : Parent
    {
        private string foo;
        public Child()
        {
            foo = "hello";
        }
        protected override void DoSomething()
        {
            Console.WriteLine(foo);
        }
    }
