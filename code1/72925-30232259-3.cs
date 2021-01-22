        public static void Main()
        {
            B[] TestArray = new B[3];
            B b1 = new B();
            C c1 = new C();
            D d1 = new D();
            TestArray[0] = b1;
            TestArray[1] = c1;
            TestArray[2] = d1;
            for (int i = 0; i < TestArray.Length; i++)
            {
                TestArray[i].MethodOne();
            }
            Console.ReadLine();
        }
    }
