    class Program
    {
        static void Main(string[] args)
        {
            base1 t1 = new type1();
            class1 c1 = new class1(t1);
            base1 t2 = new type2();
            class1 c2 = new class1(t2);
            //.....
        }
    }
    public class class1
    {
        public class1(base1 mytype)
        {
           switch(mytype.type)
               case mytype.types.type1
                   return createObjectOftype1();
               case mytype.types.type2
                   return createObjectOftype2();
               case mytype.types.type3
                   return createObjectOftype3();
        }
   
        public class1 createObjectOftype1()
        {
            //....
        }
        public class1 createObjectOftype2()
        {
           //...
        }
        public class1 createObjectOftype2()
        {
           //...
        }
    }
    public class base1
    {
        publlic Enum Types {0 "type1",.... 
    }
    public class type1:base1
    {
        //.....
    }
    public class type2:base1
    {
        //.....
    }
}
