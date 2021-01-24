    public class FlashingPictureBox : PictureBox
    {
        private int flashIntensity;
        public int FlashIntensity
        {
            get
            {
                return flashIntensity;
            }
            set
            {
                if (flashIntensity == value)
                {
                    return;
                }
                flashIntensity = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (FlashIntensity == 0)
            {
                return;
            }
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(FlashIntensity, 255, 255, 255)))
            {
                pe.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }
    } 
