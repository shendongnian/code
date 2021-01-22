    static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
           
            form1.Load += new EventHandler((s,o) =>
                {
                  //check if the form should be shown based on command line arg
                    if (args.Contains("dontShowWindow"))
                    {
                        //hide it
                        form1.ShowInTaskbar = false;
                        form1.Visible = form1.ShowInTaskbar = false;
                    }
                }
            );
            Application.Run(form1);
        }
