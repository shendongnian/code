    public class Foo 
        { 
            public NameValueCollection _nvc = null;
    
            public Foo( NameValueCollection nvc, int myInt) 
            {
                //this is cool
                _nvc = nvc;
                _nvc.Add("updated", "content");
    
                //this isn't cool. Now you have a new object with equivalent members and you should follow Matthew's advice
                //_nvc = new NameValueCollection();
                //_nvc.Add("foo", "bar");
                //_nvc.Add("updated", "content");
            } 
        }
    
        public class Bar
        {
            public static void Main()
            {
                int myInt = 10;
                NameValueCollection toPass = new NameValueCollection();
                toPass.Add("foo", "bar");
                Foo f = new Foo(toPass, myInt); 
    
                if (Object.Equals(toPass, f._nvc))
                    Console.WriteLine("true");
                else
                    Console.WriteLine("false");
                Console.ReadLine();
            }
        }
