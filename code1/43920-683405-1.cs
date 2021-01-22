    public class Main
    {
        public static void Example()
        {
            Base a = new GirlChild();
            var v = new Visitor();
            a.Visit(v);
        }
    }
    static class Ext
    {
        public static void Visit(this object b, Visitor v)
        {
            ((dynamic)v).Visit((dynamic)b);
        }
    }
    public class Visitor
    {
        public void Visit(Base b)
        {
            throw new NotImplementedException();
        }
        
        public void Visit(BoyChild b)
        {
            Console.WriteLine("It's a boy!");
        }
        public void Visit(GirlChild g)
        {
            Console.WriteLine("It's a girl!");            
        }
    }
    //Below this line are the classes you don't have to change.
    public class Base
    {
    }
    public class BoyChild : Base
    {
    }
    public class GirlChild : Base
    {
    }
