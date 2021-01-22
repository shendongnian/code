    public partial class Form1 : Form
    {
    public Form1()
        {
            InitializeComponent();
        }
      private void button1_Click(object sender, EventArgs e)
        {
            Graphics myGraphics = base.CreateGraphics();
            Pen myPen = new Pen(Color.Red);
            SolidBrush mySolidBrush = new SolidBrush(Color.Red);
            myGraphics.DrawEllipse(myPen, 50, 50, 150, 150);
        }
     }
