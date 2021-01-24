    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;
    
    namespace GraphicsTests
    {
        class DoubleGButton : Button, INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            Image m_ImageLeft = null;
            Image m_ImageRight = null;
            SizeMode m_ImageSizeMode = SizeMode.Stretch;
            Size m_ImageFixedSize = new Size(24, 24);
            Size m_ImageMaxSize = new Size(24, 24);
            public enum SizeMode : int
            {
                Stretch = 0,
                FixedSize,
                StretchMaxSize
            }
            public DoubleGButton() => InitializeComponent();
            private void InitializeComponent()
            {
                this.m_ImageLeft = default;
                this.m_ImageRight = default;
                base.MinimumSize = new Size(32, 24);
                this.TextAlign = ContentAlignment.MiddleCenter;
            }
            public Image ImageLeft {
                get { return this.m_ImageLeft; }
                set { this.m_ImageLeft = value; this.Invalidate(); } }
            public Image ImageRight {
                get { return this.m_ImageRight; }
                set { this.m_ImageRight = value; this.Invalidate(); } }
            public SizeMode ImageSizeMode {
                get { return this.m_ImageSizeMode; }
                set { this.m_ImageSizeMode = value;
                      NotifyPropertyChanged(nameof(this.ImageSizeMode)); } }
            public Size ImageFixedSize {
                get { return this.m_ImageFixedSize; }
                set { this.m_ImageFixedSize = value;
                      NotifyPropertyChanged(nameof(this.ImageFixedSize)); } }
            public Size ImageMaxSize {
                get { return this.m_ImageMaxSize; }
                set { this.m_ImageMaxSize = value;
                      NotifyPropertyChanged(nameof(this.ImageMaxSize)); } }
            private void NotifyPropertyChanged(string PropertyName)
            {
                this.Invalidate();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                List<RectangleF> ImageBoxes = GetImageBoxes();
                if (this.m_ImageLeft != null)
                {
                    e.Graphics.DrawImage(this.ImageLeft, ImageBoxes[0]);
                }
                if (this.m_ImageRight != null)
                {
                    e.Graphics.DrawImage(this.ImageRight, ImageBoxes[1]);
                }
            }
            private List<RectangleF> GetImageBoxes()
            {
                List<RectangleF> rects = new List<RectangleF>();
                RectangleF rectImageLeft = RectangleF.Empty;
                RectangleF rectImageRight = RectangleF.Empty;
                switch (ImageSizeMode)
                {
                    case SizeMode.Stretch:
                        rectImageLeft = new RectangleF(new PointF(6, 6), new SizeF(this.Width / 10, this.Height - 12));
                        rectImageRight = new RectangleF(new PointF((this.Width - (this.Width / 10)) - 6, 6), 
                                                        new SizeF(this.Width / 10, this.Height - 12));
                        break;
                    case SizeMode.FixedSize:
                        float TopPosition = (this.Height - this.ImageFixedSize.Height) / 2;
                        rectImageLeft = new RectangleF(new PointF(6, TopPosition), 
                                                       new SizeF(this.ImageFixedSize.Width, this.ImageFixedSize.Height));
                        rectImageRight = new RectangleF(new PointF(this.Width - this.ImageFixedSize.Width - 6, TopPosition), 
                                                        new SizeF(this.ImageFixedSize.Width, this.ImageFixedSize.Height));
                        break;
                    case SizeMode.StretchMaxSize:
                        float BoxHeight = (this.Height - 12 > this.ImageMaxSize.Height) ? this.ImageMaxSize.Height : this.Height - 12;
                        float TopBoxPosition = (this.Height - BoxHeight) / 2;
                        float imageHeight = (BoxHeight > this.ImageMaxSize.Height) ? this.ImageMaxSize.Height : BoxHeight;
                        float imageWidth = this.ImageLeft.Width / (this.ImageLeft.Height / imageHeight);
                        imageWidth = (imageWidth > this.ImageMaxSize.Width) ? this.ImageLeft.Width : imageWidth;
                        rectImageLeft = new RectangleF(new PointF(6, TopBoxPosition), 
                                                       new SizeF(imageWidth, imageHeight));
                        rectImageRight = new RectangleF(new PointF(this.Width - imageWidth - 6, TopBoxPosition), 
                                                        new SizeF(imageWidth, imageHeight));
                        break;
                    default:
                        break;
                }
                rects.AddRange(new[] { rectImageLeft,  rectImageRight });
                return rects;
            }
        }
    }
