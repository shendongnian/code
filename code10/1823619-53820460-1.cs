    public class myForm: Form
    {   
        int x=0;
        AutoResetEvent auto;
        public myForm()
        {
            auto = new AutoResetEvent(false);
            InitializeComponent();
        }
        public int myFunction() {
            //do something
            //wait for button1's click
            auto.WaitOne();
            return x;
        } 
      private void button1_Click(object sender, EventArgs e)
        {
           // using this button to change the value of x
          x=2;
          auto.Set();
        }
    }
