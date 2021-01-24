    public partial class Form1 : Form
        {
            Timer t;
            MouseButtons LastMouseButtonClicked;
            Label lblStatus;
    
            public Form1()
            {
                InitializeComponent();
    
                lblStatus = new Label()
                {
                    Text = "No click since tick."
                    ,Width = 1000
                };
                this.Controls.Add(lblStatus);
    
                t = new Timer();
                //A single tick represents one hundred nanoseconds or one ten-millionth of a second. There are 10,000 ticks in a millisecond, or 10 million ticks in a second.
                //t.Interval = (int)(100 / TimeSpan.TicksPerMillisecond);//0.01 ms
                t.Interval = 1000;
                t.Tick += T_Tick;
                t.Enabled = true;
    
                this.MouseClick += Form1_MouseClick;
            }
    
            private void T_Tick(object sender, EventArgs e)
            {
                switch (LastMouseButtonClicked)
                {
                    case MouseButtons.Left:
                        //Action...
                        lblStatus.Text = "MouseButtons.Left " + DateTime.Now.Ticks;
                        break;
                    case MouseButtons.Right:
                        //Action...
                        lblStatus.Text = "MouseButtons.Right " + DateTime.Now.Ticks;
                        break;
                    default:
                        lblStatus.Text = "No click since tick. " + DateTime.Now.Ticks;
                        break;
                }
            }
    
            private void Form1_MouseClick(object sender, MouseEventArgs e)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        LastMouseButtonClicked = e.Button;
                        t.Interval = 1000;
                        break;
                    case MouseButtons.Right:
                        LastMouseButtonClicked = e.Button;
                        t.Interval = 3000;
                        break;
                }
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
        }
