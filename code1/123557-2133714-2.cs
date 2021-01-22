    class Program
    {
        private static ManualResetEvent[] resetEvents;
        [ThreadStatic]
        static ScriptControlClass s;
        private void cs(object o)
        {
            int xx = 0;
            if (s == null)
            {
                s = new ScriptControlClass();
            }
            /* you should be able to see consistent memory usage after 30 iterations */
            while (xx < 30)
            {
                xx++;
                //Unsure why this is here but doesn't seem to affect the memory usage
                //  like the ScriptControlClass object.
                System.Xml.XmlDocument document = new System.Xml.XmlDocument();
                document.Load("ConsoleApplication6.exe.config");
                s.Language = "JScript";
                object res = s.Eval("1+2");
                Console.WriteLine("thread {0} execution {1}", o, xx);
                System.Threading.Thread.Sleep(5000);
            }
            s = null;
        }
        static void Main(string[] args)
        {
            Program c = new Program();
            for (int i = 0; i < 1000; i++)
            {
                System.Threading.Thread t = new System.Threading.Thread(
                    new System.Threading.ParameterizedThreadStart(c.cs));
                t.Start((object)i);
            }
        }
    }
  
