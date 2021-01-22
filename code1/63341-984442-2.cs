    using System.Windows.Forms;
    
    class MyForm : Form
    {
        private Timer myTimer;
        private Button myButton;
        
        private MyController myController;
    
        public MyForm()
        {
            // ...
            // Initialize the components, etc.
            // ...
    
            myTimer.Tick += new EventHandler( myTimer_Tick );
            myButton.Click += new EventHandler( myButton_Click );
    
            myTimer.Start();
        }
    
        private void myTimer_Tick( object sender, EventArgs eventArgs )
        {
            myTimer.Stop();
            myController.SomeMethod()
        }
    
        private void myButton_Click( object sender, EventArgs eventArgs )
        {
            // All the stuff done here will likely be moved 
            // into MyController.SomeMethod()
            myController.SomeMethod();
        }
    }
