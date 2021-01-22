      public partial class Form1 : Form
      {
        const int WS_EX_NOACTIVATE = 0x08000000;
    
        public Form1()
        {      
          InitializeComponent();      
        }
    
        protected override CreateParams CreateParams
        {
          get
          {
            CreateParams param = base.CreateParams;
            param.ExStyle |= WS_EX_NOACTIVATE;
            return param;
          }
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          SendKeys.Send("A");
        }
      }
