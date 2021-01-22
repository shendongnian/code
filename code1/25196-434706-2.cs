    using System;
    using System.Windows.Forms;
    using System.Drawing;
    public class TransparentControl : Control
    {
        private readonly Timer refresher;
        private Image _image;
        public TransparentControl()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            refresher = new Timer();
            refresher.Tick += TimerOnTick;
            refresher.Interval = 50;
            refresher.Enabled = true;
            refresher.Start();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
        protected override void OnMove(EventArgs e)
        {
            RecreateHandle();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_image != null)
            {
                e.Graphics.DrawImage(_image, (Width / 2) - (_image.Width / 2), (Height / 2) - (_image.Height / 2));
            }
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
           //Do not paint background
        }
        //Hack
        public void Redraw()
        {
            RecreateHandle();
        }
        private void TimerOnTick(object source, EventArgs e)
        {
            RecreateHandle();
            refresher.Stop();
        }
        public Image Image
        {
            get
            {
                return _image;
            }
            set
            {
                _image = value;
                RecreateHandle();
            }
        }
    }
