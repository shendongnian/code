    class Program
    {
        static void Main(string[] args)
        {
            IBase obj = new BaseElement();
            IElement obj1 = new Element01();
            obj.method01();//call base
            obj1.method01();
            Console.ReadLine();
        }
    }
    public interface IBase
    {
        void method01();
    }
    public interface IElement
    {
        void method01();
    }
    public class BaseElement : IBase
    {
        public BaseElement() { }
        void IBase.method01()
        {
            Console.WriteLine("class BaseElement method01");
        }
    }
    public class Element01 : BaseElement, IElement
    {
        public Element01() { }
        public void method01()
        {
            Console.WriteLine("class Element02 method01");
        }
    }
    public class Element02 : BaseElement, IElement
    {
        public Element02() { }
        public void method01()
        {
            Console.WriteLine("class Element02 method01");
        }
    }
