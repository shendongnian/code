        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                float f = 0.479f;
                Console.WriteLine(f.ToString("p1")); //will write 47.9%
                CultureInfo ci = CultureInfo.CurrentCulture.Clone() as CultureInfo;
                ci.NumberFormat.PercentSymbol = "";            
                System.Threading.Thread.CurrentThread.CurrentCulture = ci;
                Console.WriteLine(f.ToString("p1")); //will write 47.9
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
