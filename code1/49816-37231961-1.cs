    public class Base : StaticBase<Base>
    {
        public Base()
        {
        }
        public void MethodA()
        {
        }
    }
    public class Inherited : Base
    {
        private Inherited()
        {
        }
        public new static void MethodA()
        {
            Instance.MethodA();
        }
    }
