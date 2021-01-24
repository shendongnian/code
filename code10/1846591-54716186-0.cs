     public abstract class BaseElement
    {
        public BaseElement() { }
        public  void method01()
        {
            Console.WriteLine("class BaseElement method01");
            method01Int();
        }
        protected abstract void method01Int();
    }
    public class Element01 : BaseElement
    {
        public Element01() { }
        protected override void method01Int()
        {
            Console.WriteLine("class Element01 method01");
        }
    }
    public class Element02 : BaseElement
    {
        public Element02() { }
        protected override void method01Int()
        {
            Console.WriteLine("class Element02 method01");
        }
    }
