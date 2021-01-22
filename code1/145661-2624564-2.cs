      public partial class Form1 : Form
      {
        private HalloForm _hallo;
        private Timer _timer;
    
        public Form1()
        {
          InitializeComponent();
          _hallo = new HalloForm();
          _timer = new Timer() { Interval = 20, Enabled = true };
          _timer.Tick += new EventHandler(Timer_Tick);
        }
    
        void Timer_Tick(object sender, EventArgs e)
        {
          Point pt = Cursor.Position;
          pt.Offset(-(_hallo.Width / 2), -(_hallo.Height / 2));
          _hallo.Location = pt;
    
          if (!_hallo.Visible)
          {
            _hallo.Show();
          }
        }    
      }
    
      public class HalloForm : Form
      {        
        public HalloForm()
        {
          TopMost = true;
          ShowInTaskbar = false;
          FormBorderStyle = FormBorderStyle.None;
          BackColor = Color.LightGreen;
          TransparencyKey = Color.LightGreen;
          Width = 100;
          Height = 100;
    
          Paint += new PaintEventHandler(HalloForm_Paint);
        }
    
        void HalloForm_Paint(object sender, PaintEventArgs e)
        {      
          e.Graphics.DrawEllipse(Pens.Black, (Width - 25) / 2, (Height - 25) / 2, 25, 25);
        }
      }
