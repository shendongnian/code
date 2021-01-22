        //program.cs
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0)
            {
                //launch same form as normal or different
                Application.Run(new Form1(args));
            }
            else
            {
                Application.Run(new Form1());
            }
        }
