    class CPUMoon : AbstractCPU
    {
        public string message {get;set;}
        public override void DisplayName(AbstractCPU a)
        {
            //Form1 f1 = new Form1();
    
            // create reader & open file
            StreamReader tr = new StreamReader("Moon.txt");
            String fromFile = tr.ReadLine();
            // close the stream
            tr.Close();
            message = "CPU diagnosing has be done for   " + a.GetType().Name + "                " + fromFile;
            //Console.WriteLine("CPU diagnosing has be done for   " + a.GetType().Name + "                //" + fromFile);
        }
    }
