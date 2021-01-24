    public class BaseElement
    {
        public BaseElement() { }
        public virtual void method01()
        {
            Console.WriteLine("class BaseElement method01");
        }
    }
    public abstract class MiddleElement: BaseElement
    {
        public abstract override void method01();
    };
    
    public class Element01 : MiddleElement
    {
        public Element01() { }
        public override void method01()
        {
            Console.WriteLine("class Element02 method01");
        }
    }
    public class Element02 : MiddleElement
    {
        public Element02() { }
        public override void method01()
        {
            Console.WriteLine("class Element02 method01");
        }
    }
