    public class Test
    {
        public static void Exec()
        {
             Program.thr1.Abort();
             Program.thr1= new System.Threading.Thread(() => Class1.DoSomething(param1, param2));
            Program.thr1.Start();
        }
    }
