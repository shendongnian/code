    class Test
    {
        public void Print(int n)
        {
            Console.WriteLine(n);
        }
    }
    class MainA
    {
       static void Main()
        { 
            Type t = typeof(Test);
            Object obj = new Test();
            System.Reflection.MethodInfo m = t.GetMethod("Print");
            m.Invoke(obj,new object[]{11});
        }
    }
