    public class MyImageProcessor : Interface1, Interface2{
        private static ServerForm sv;      
        public MyImageProcessor () {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            sv = new ServerForm();
            Application.Run(sv);
        }
    }
