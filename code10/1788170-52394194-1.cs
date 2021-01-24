    public partial class Form : Form
    {
        Timer t = new Timer();
        private YourFirstForm myFirstForm;
        public Form(YourFirstForm form)
        {
            InitializeComponents();
            myFirstForm = form;
            t.Interval = 200; //0.2 sec 
            Thread t1 = new Thread(FirstFormListener);
            t1.Start();
        }
        private void FirstFormListner()
        {
            Timer t = new Timer();
            t.Interval = 200; //0.2 sec
            
            t.Tick += new EventHandler(timer1_Tick); 
            t.Enabled = true; 
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            MyNewObject someData = myFirstForm.GetSomeData();
            MessageBox.Show(someData.Name);
        }
    }
