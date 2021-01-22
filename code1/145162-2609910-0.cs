    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.DoubleBuffered = true;
                this.AutoScroll = true;
                for (int i = 0; i < 100; i++)
                    this.Controls.Add(new Rectangle() { Top = i * 120, Left = 10 });
    
            }
        }
    
        public class Rectangle : Control
        {
            public Rectangle()
            {
                this.Width = 100;
                this.Height = 100;
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.DrawRectangle(new Pen(Color.Black, 5), 0, 0, 100, 100);
            }
        }
