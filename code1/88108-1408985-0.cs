    public class A
    {
        public void methodA()
        {
            try
            {
            }
            catch(Exception e)
            {
                 throw new Exception("Some description", e);
            }
        }
    }
    public class B
    {
        public void methodB()
        {
            try
            {
                 A a = new A();
                 a.methodA();
            }
            catch(Exception e)
            {
                //...here you get exceptions
            }
        }
    }
