    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var y = SomeFunctionThatReturnsY();
            MessageBox.Show(y.bla);
            return;
        }
        private Y SomeFunctionThatReturnsY()
        {
            return new Y();
        }
    }
    internal class X { }
    internal class Y : X
    {
        public string bla = "Saw a Y, not an X";
    }
