    public class CountVisitor : IVisitor<int, IVisitable>
    {
       public int Visit( IVisitable v )
       {
           dynamic d = v;
           Visit(d);
       }
        private int Visit( Foo f ) 
        {
            return 42;
        }
  
        private int Visit( Bar b )
        {
            return 7;
        }
    }
