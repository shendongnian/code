    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(new SuperButton());
        }
    }
    public class SuperButton : Button
    {
        protected override void Dispose(bool disposing)
        {
            //Place breakpoint on the line below
            base.Dispose(disposing); 
        }
    }
