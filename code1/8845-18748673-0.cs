    public partial class Form1 : Form
    {
        private ExampleController.MyController controller;
        public Form1()
        {          
            InitializeComponent();
            controller = new ExampleController.MyController((ISynchronizeInvoke) this);
            controller.Finished += controller_Finished;
            
        }
        void controller_Finished(string returnValue)
        {
            label1.Text = returnValue;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            controller.SubmitTask("Do It");
        }
    }
