    using System.Drawing;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp2
    {
        public partial class Form1 : Form
        {
            Point _coordinates;
            public Form1()
            {
                this._coordinates = new Point();
                this.InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
            }
    
            public void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                this._coordinates = new Point(e.X, e.Y);
                this.Invalidate();
            }
            private void Form1_Paint(object sender, PaintEventArgs e)
            {
                // Don't draw on first Paint event
                if(this._coordinates.X != 0 && this._coordinates.Y != 0)
                {
                    this.DrawRect(e);
                }
            }
    
            public void DrawRect(PaintEventArgs e)
            {
                using (Pen pen = new Pen(Color.Azure, 4))
                {
                    Rectangle rect = new Rectangle(0, 0, this._coordinates.X, this._coordinates.Y);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
    }
