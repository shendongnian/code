    internal static class Program
    {
        private static Mutex m;
        [STAThread]
        private static void Main()
        {
            bool flag;
            m = new Mutex(true, "ProgramName", out flag);
            if (!flag)
            {
                MessageBox.Show("Another instance is already running.");
            }
            else
            {
                //start program
            }
        }
    }
