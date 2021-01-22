        public partial class Form1 : Form
        {
            private Ball ball;
            private Timer timer;
            public Form2()
            {
                InitializeComponent();
                this.ball = new Ball
                {
                    X = 10f,
                    Y = 10f,
                    DX = 2f,
                    DY = 2f,
                    Color = Color.Red,
                    Size = 10f
                };
                this.timer = new Timer();
                timer.Interval = 20;
                timer.Tick += new EventHandler(timer_Tick);
                timer.Start();
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                var left = KeyboardInfo.GetKeyState(Keys.Left);
                var right = KeyboardInfo.GetKeyState(Keys.Right);
                var up = KeyboardInfo.GetKeyState(Keys.Up);
                var down = KeyboardInfo.GetKeyState(Keys.Down);
    
                if (left.IsPressed)
                {
                    ball.MoveLeft();
                    this.Invalidate();
                }
    
                if (right.IsPressed)
                {
                    ball.MoveRight();
                    this.Invalidate();
                }
    
                if (up.IsPressed)
                {
                    ball.MoveUp();
                    this.Invalidate();
                }
    
                if (down.IsPressed)
                {
                    ball.MoveDown();
                    this.Invalidate();
                }
    
                
            }
    
    
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                if (this.ball != null)
                {
                    this.ball.Draw(e.Graphics);
                }
            }
        }
