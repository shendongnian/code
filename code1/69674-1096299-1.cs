        public void TestMyClass()
        {
            MyClass c = new MyClass();
            IThing other = GetMock();
            c.Save(other);
            c.DoSomething();
            other.AssertWasCalled(o => o.SomeMethod());
        }
