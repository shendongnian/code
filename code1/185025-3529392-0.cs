    public class Parent
    {
        private void PrivateMethod()
        {
        }
        
        class Child : Parent
        {
            public void Foo()
            {
                PrivateMethod();
            }
        }
    }
