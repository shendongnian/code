    public interface IElement
    {
        void method01();
    }
    
    public class BaseElement: IElement
    {
        public BaseElement() { }
        public void method01()
        {
            Console.WriteLine("class BaseElement method01");
        }
    }
    public class Element01 : BaseElement, IElement
    {
        public Element01() { }
        public new void method01()
        {
            Console.WriteLine("class Element01 method01");
        }
    }
    public class Element02 : BaseElement, IElement
    {
        public Element02() { }
        public new void method01()
        {
            Console.WriteLine("class Element02 method01");
        }
    }
