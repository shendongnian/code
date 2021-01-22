    public partial class Form1 : Form
    {
        private Bitmap _canvas;
        private float _sweepStartAngle = -90;
        private float _sweepAngle = 15;
        private SolidBrush _sweepBrush = new SolidBrush(Color.Red);
        private Rectangle _sweepRect;
        private Timer _sweepTimer = new Timer();
        private Bitmap _submarine;
        private Point _submarinePosition = new Point(0, 0);
        private Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            _canvas = new Bitmap(pbScope.Width, pbScope.Height);
            pbScope.Image = _canvas;
            _sweepRect = new Rectangle(0, 0, pbScope.Width, pbScope.Height);
            _submarine = (Bitmap)pbSubmarine.Image;
            
            RedrawScope();
            _sweepTimer.Interval = 100;
            _sweepTimer.Tick += new EventHandler(_sweepTimer_Tick);
            _sweepTimer.Start();
        }
        void _sweepTimer_Tick(object sender, EventArgs e)
        {
            _sweepStartAngle += _sweepAngle;
            RedrawScope();
        }
        private void RedrawScope()
        {
            using (Graphics g = Graphics.FromImage(_canvas))
            {
                // draw the background
                g.DrawImage(pbBackground.Image, 0, 0);
                // draw the "sweep"
                GraphicsPath piepath = new GraphicsPath();
                piepath.AddPie(_sweepRect, _sweepStartAngle, _sweepAngle);
                g.FillPath(_sweepBrush, piepath);
                //g.FillPie(_sweepBrush, _sweepRect, _sweepStartAngle, _sweepAngle);
                
                // move the submarine and draw it
                _submarinePosition.X += rnd.Next(3);
                _submarinePosition.Y += rnd.Next(3);
                // check if submarine intersects with piepath
                Rectangle rect = new Rectangle(_submarinePosition, _submarine.Size);
                Region region = new Region(piepath);
                region.Intersect(rect);
                if (!region.IsEmpty(g))
                {
                    g.DrawImage(_submarine, _submarinePosition);
                }
            }
            pbScope.Image = _canvas;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sweepTimer.Stop();
            _sweepTimer.Dispose();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //GraphicsPath piepath = new GraphicsPath();
            //piepath.AddPie(
            
        }
    }
       private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbScope = new System.Windows.Forms.PictureBox();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.pbSubmarine = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbScope)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubmarine)).BeginInit();
            this.SuspendLayout();
            // 
            // pbScope
            // 
            this.pbScope.Location = new System.Drawing.Point(12, 12);
            this.pbScope.Name = "pbScope";
            this.pbScope.Size = new System.Drawing.Size(300, 300);
            this.pbScope.TabIndex = 0;
            this.pbScope.TabStop = false;
            // 
            // pbBackground
            // 
            this.pbBackground.Image = ((System.Drawing.Image)(resources.GetObject("pbBackground.Image")));
            this.pbBackground.Location = new System.Drawing.Point(341, 12);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(300, 300);
            this.pbBackground.TabIndex = 1;
            this.pbBackground.TabStop = false;
            this.pbBackground.Visible = false;
            // 
            // pbSubmarine
            // 
            this.pbSubmarine.Image = ((System.Drawing.Image)(resources.GetObject("pbSubmarine.Image")));
            this.pbSubmarine.Location = new System.Drawing.Point(658, 45);
            this.pbSubmarine.Name = "pbSubmarine";
            this.pbSubmarine.Size = new System.Drawing.Size(48, 48);
            this.pbSubmarine.TabIndex = 2;
            this.pbSubmarine.TabStop = false;
            this.pbSubmarine.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 328);
            this.Controls.Add(this.pbSubmarine);
            this.Controls.Add(this.pbBackground);
            this.Controls.Add(this.pbScope);
            this.Name = "Form1";
            this.Text = "Radar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbScope)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubmarine)).EndInit();
            this.ResumeLayout(false);
        }
