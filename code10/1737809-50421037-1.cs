    public Form1()
    {
        InitializeComponent();
        ball = new Ball(new Point(250, 250));
        ball.State = 1;  // <- Will draw a green ball
        this.Paint += (s, e) => { ball.Draw(e.Graphics); };
        this.FormClosing += (s, e) => { ball.Dispose(); };
    }
    public Ball ball { get; set; }
