csharp
namespace timerbug
{
    public partial class Form1 : Form
    {
        int value;
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (value < 5)
            {
                value++;
                label1.Text = value.ToString();
            }
            else
            {
                times1.Stop();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            value = 0;
            timer1.Start();
        }
    }
}
