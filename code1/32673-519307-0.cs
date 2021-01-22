    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            new Thread( SampleFunction ).Start();
        }
        void SampleFunction()
        {
            // Gets executed on a seperate thread and 
            // doesn't block the UI while sleeping
            for ( int i = 0; i < 5; i++ )
            {
                this.Invoke( ( MethodInvoker )delegate()
                {
                    textBox1.Text += "hi";
                } );
                Thread.Sleep( 1000 );
            }
        }
    }
