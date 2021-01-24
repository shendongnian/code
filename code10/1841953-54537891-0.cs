    private System.Windows.Forms.Timer _timer;
    private int _timer_i;
    public Form1()
    {
      InitializeComponent();
      _timer = new System.Windows.Forms.Timer()
      {
        Enabled = false,
        Interval = 200
      };
      _timer.Tick += _timer_Tick;
    }
    private void _timer_Tick(object sender, EventArgs e)
    {
      textBox1.Text = _timer_i.ToString();
      _timer_i++;
      if (_timer_i >= 10)
      {
        _timer.Stop();
      }
    }
    private void button1_Click(object sender, EventArgs e)
    {
      _timer.Stop();
      _timer_i = 0;
      _timer.Start();
    }
