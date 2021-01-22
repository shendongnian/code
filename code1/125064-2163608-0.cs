      static void Main(string[] args)
        {
            using (tw = new StreamWriter("TextFile1.txt"))
            {
                Timer t = new Timer(1000);
                t.Elapsed += new ElapsedEventHandler(SaniyelikIs);
                t.Start();
                Console.Read();
                t.Stop();
                tw.Close();
            }
        }
        static void SaniyelikIs(object o, ElapsedEventArgs a)
        {
            // write a line of text to the file
            tw.WriteLine(DateTime.Now);
        }
