    using System.Drawing;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
            }
    
            public void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                int x = e.X;
                int y = e.Y;
                String data = (x.ToString() + " " + y.ToString());
                DrawRect(x, y);
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                // You don't need that
            }
    
            public void DrawRect(PaintEventArgs e, int rey, int rex)
            {
                using (Graphics gr = this.CreateGraphics())
                {
                    using (Pen pen = new Pen(Color.Azure, 4))
                    {
                        Rectangle rect = new Rectangle(0, 0, rex, rey);
                        gr.DrawRectangle(pen, rect);
                    }
                }
            }
        }
    }
