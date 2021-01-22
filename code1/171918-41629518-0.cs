    public partial class Form1 : Form
    {
        Pen mypen;
        Color mycolor=Color.Red;
        Graphics mygraph;
        int xloc = 50, yloc = 50;
        
        public Form1()
        {
            InitializeComponent();
            mygraph = CreateGraphics();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
        float x = 270, y = 0.5f;
        int xmover = 100, ymover = 48;
        private void timer1_Tick(object sender, EventArgs e)
        {
            mygraph.DrawEllipse(new Pen(Color.Red), xloc, yloc, 102, 102);
            mygraph.FillEllipse(new SolidBrush(Color.Red), xmover++, ymover++, 4, 4);
            mycolor = this.BackColor;
            mygraph.DrawPie(new Pen(mycolor), xloc+1, yloc+1, 100, 100, x-1, y);
            mygraph.DrawPie(new Pen (Color.Red), xloc + 1, yloc + 1, 100, 100, x++, y);
            mygraph.FillEllipse(new SolidBrush(mycolor), xmover-1, ymover - 1, 4, 4);
            mygraph.DrawEllipse(new Pen(Color.Red), 100, 50, 5, 5);
        }
    }
}
