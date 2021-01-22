    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
    
            this.MouseWheel += new MouseEventHandler(MouseWheelEvent);
            this.MouseMove += new MouseEventHandler(MouseWheelEvent);
        }
    
        private void MouseWheelEvent(object sender, MouseEventArgs e)
        {
            Console.Out.WriteLine(e.Delta);
        }
    }
