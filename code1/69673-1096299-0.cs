        public void TestMyClass()
        {
            MyClass c = new MyClass();
            MyOtherClass other = new MyOtherClass();
            c.Save(other);
            var result = c.Retrieve();
            Assert.IsTrue(result.Contains(other));
        }
