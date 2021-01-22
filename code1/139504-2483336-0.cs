    //Minimal example, for demonstration only.
    //No Equals(), GetHaschode() overload, no IEquatable<T>, null checks, etc..
    class Program
    {
        static void Main()
        {
            MyMoreDerived a = new MyMoreDerived() { fbase = 1, fderived = 3 };
            MyMoreDerived b = new MyMoreDerived() { fbase = 2, fderived = 3 };
            
            //Even though MyMoreDerived does not overload the operators, this
            //will succeed - the definition in MyDerived will be used.
            if (a == b)
            {
                //Reached, because the operator in MyDerived is used.
                Console.WriteLine("MyDerived operator used: a == b");
            }
            a.fderived = 2;
            b.fbase = 1;
            //a => {1, 2} 
            //b => {1, 3}
            //Since 2 != 3, the operator in MyDerived would return false.
            //However only the operator in MyBase will be used.
            if ((MyBase)a == (MyBase)b)
            {
                //Reached, because the operator in MyBase is used.
                Console.WriteLine("MyBase operator used: a == b");
            }
            b.fderived = 2;
            //a => {1, 2} 
            //b => {1, 2}
            //Now both operator definitions would compare equal,
            //however they are not used.
            if ((object)a != (object)b)
            {
                //Reached, because the default implementation is used
                //and the references are not equal.
                Console.WriteLine("Default operator used: a != b");
            }
        }
        
        class MyBase
        {
            public int fbase;
            public static bool operator ==(MyBase x, MyBase y)
            {
                return x.fbase == y.fbase;
            }
            public static bool operator !=(MyBase x, MyBase y)
            {
                return !(x.fbase == y.fbase);
            }
        }
        class MyDerived : MyBase
        {
            public int fderived;
            public static bool operator ==(MyDerived x, MyDerived y)
            {
                return x.fderived == y.fderived;
            }
            public static bool operator !=(MyDerived x, MyDerived y)
            {
                return !(x.fderived == y.fderived);
            }
        }
        class MyMoreDerived : MyDerived
        {
        }
    }
