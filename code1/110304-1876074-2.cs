        public partial class Form2 : Form
        {
          [STAThread]
          static void Main()
          {
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new Form2());
          }
        }
