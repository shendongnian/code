    public class B1
    {
            public static void MyFunc(){ ; }
    }
    
    public class B2
    {
            private B1 b1;
    
            public B1 B1
            {
                    get { return b1; }
                    set { b1 = value; }
            }
    
            public void Foo(){
                    B1.MyFunc();
            }
    }
