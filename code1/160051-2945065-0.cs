     public partial class Form1 : Form
    {
        int left;
        int top;
        bool flgAllTheWayToTheRight = false;
        bool flgAllTheWayToTheBottom = false;
        public Form1()
        {
            // on my form I have two timers, named timer1 and tmrDraw
            // and then I have label1
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (left <= 100)
            { left++; }
            else
            { flgAllTheWayToTheRight = true; }
            if (flgAllTheWayToTheRight)
            {
                if (top <= 150)
                { top++; }
                else
                { flgAllTheWayToTheBottom = true; }
            }
            if (flgAllTheWayToTheBottom && flgAllTheWayToTheRight)
            {
                left = 0;
                top = 0;
                flgAllTheWayToTheRight = false;
                flgAllTheWayToTheBottom = false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Animate Me.";
            timer1.Interval = 10;
            tmrDraw.Interval = 10;
            timer1.Start();
            tmrDraw.Start();
        }
        private void tmrDraw_Tick(object sender, EventArgs e)
        {
            label1.Left = left;
            label1.Top = top;
        }
    }
