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
        private string foo = "HELLO";
        protected override void DoSomething()
        {
            Console.WriteLine(foo.ToLower());
        }
    }
