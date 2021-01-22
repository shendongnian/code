    using System;
    using System.Windows.Forms;
    
    namespace ClosingFormWithException
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            public delegate void InvokeDelegate();
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                try
                {
                    MyTroublesomeClass myClass = new MyTroublesomeClass();
                }
                catch (ApplicationException ex)
                {
                 
                    MessageBox.Show("There was a critical error.  The form will close.  Please try again.");
    
                    this.BeginInvoke(new InvokeDelegate(CloseTheForm));
                }
    
            }
            private void CloseTheForm()
            {
                this.Close();
            }
        }
    
        class MyTroublesomeClass
        {
            public MyTroublesomeClass()
            {
                throw new ApplicationException();
            }
        }
    }
  
