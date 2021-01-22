    public class AnotherObject
    {
        public void SomeMethod(IWidget widget1)
        {
            //..do something with widget1
        }
    }
    public class CallingObject
    {
        public void AnotherMethod()
        {
            IWidget widget1 = new Widget();
            new AnotherObject().SomeMethod(widget1);
        }
    }
