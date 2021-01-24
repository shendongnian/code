    namespace Sample7
    {
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
 
        bool ctrlKeyDown;
        bool shiftKeyDown;
 
        private void Form4_Load(object sender, EventArgs e)
        {
            this.ctrlKeyDown = false;
            this.shiftKeyDown = false;
 
            //If there's only PictureBox control on the panel, the MouseWheel event of the form raised
            //instead of the MouseWheel event of the Panel.
            this.MouseWheel += new MouseEventHandler(Form4_MouseWheel);
            this.KeyDown += new KeyEventHandler(Form4_KeyDown);
            this.KeyUp += new KeyEventHandler(Form4_KeyUp);
 
            //this is important for zooming the image
            this.pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        void Form4_KeyUp(object sender, KeyEventArgs e)
        {
            this.ctrlKeyDown = e.Control;
            this.shiftKeyDown = e.Shift;
        }
 
        void Form4_KeyDown(object sender, KeyEventArgs e)
        {
            this.ctrlKeyDown = e.Control;
            this.shiftKeyDown = e.Shift;
        }
 
        void Form4_MouseWheel(object sender, MouseEventArgs e)
        {
            bool IsGoUp = e.Delta > 0 ? true : false;
 
            if (this.ctrlKeyDown)
            {
                if (IsGoUp && this.panel1.HorizontalScroll.Value > 5)
                {
                    this.panel1.HorizontalScroll.Value -= 5;
                }
                if (!IsGoUp && this.panel1.HorizontalScroll.Value < this.panel1.HorizontalScroll.Maximum - 5)
                {
                    this.panel1.HorizontalScroll.Value += 5;
                }
            }
            else if (this.shiftKeyDown)
            {
                int hStep = (int)(this.pictureBox2.Image.Width * 0.02);
                int vStep = (int)(this.pictureBox2.Image.Height * 0.02);
                if (IsGoUp)
                {
                    this.pictureBox2.Width += hStep;
                    this.pictureBox2.Height += vStep;
                }
                else
                {
                    this.pictureBox2.Width -= hStep;
                    this.pictureBox2.Height -= vStep;
                }
            }
            else
            {
                if (IsGoUp && this.panel1.VerticalScroll.Value > 5)
                {
                    this.panel1.VerticalScroll.Value -= 5;
                }
                if (!IsGoUp && this.panel1.VerticalScroll.Value < this.panel1.VerticalScroll.Maximum - 5)
                {
                    this.panel1.VerticalScroll.Value += 5;
                }
            }
        }
    }
}
