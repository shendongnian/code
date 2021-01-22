    public static void Test()
    {
        B t = new B(true);
        B f = new B(false);
        
        B result = f || t && f;
        
        Console.WriteLine("-----");
        Console.WriteLine(result);
    }
    public class B {
        bool val;
        public B(bool val) { this.val = val; }
        public static bool operator true(B b) { return b.val; }
        public static bool operator false(B b) { return !b.val; }
        public static B operator &(B lhs, B rhs) { 
            Console.WriteLine(lhs.ToString() + " & " + rhs.ToString());
            return new B(lhs.val & rhs.val); 
        }
        public static B operator |(B lhs, B rhs) { 
            Console.WriteLine(lhs.ToString() + " | " + rhs.ToString());
            return new B(lhs.val | rhs.val); 
        }
        public override string ToString() { 
            return val.ToString(); 
        }
    }
    
