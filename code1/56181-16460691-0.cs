        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            objfrmmain = new Frm_Main();
            Showtop();//this is procedure in program.cs to load an other form, so if that contain's tool tip control then it will not work
            Application.Run(objfrmmain);
        }
