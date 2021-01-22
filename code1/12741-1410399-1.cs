    public class MonthCalendarEx : System.Windows.Forms.MonthCalendar
    {
        private int _offsetX;
        private int _offsetY;
        private int _dayBoxWidth;
        private int _dayBoxHeight;
        private bool _repaintSelectedDays = false;
        public MonthCalendarEx() : base()
        {
            OnSizeChanged(null, null);
            this.SizeChanged += OnSizeChanged;
            this.DateChanged += OnSelectionChanged;
            this.DateSelected += OnSelectionChanged;
        }
        protected static int WM_PAINT = 0x000F;
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                Graphics graphics = Graphics.FromHwnd(this.Handle);
                PaintEventArgs pe = new PaintEventArgs(
                    graphics, new Rectangle(0, 0, this.Width, this.Height));
                OnPaint(pe);
            }
        }
        private void OnSelectionChanged(object sender, EventArgs e)
        {
            _repaintSelectedDays = true;
        }
        private void OnSizeChanged(object sender, EventArgs e)
        {                         
            _offsetX = 0;
            _offsetY = 0;
            // determine Y offset of days area 
            while (
                HitTest(Width / 2, _offsetY).HitArea != HitArea.PrevMonthDate &&
                HitTest(Width / 2, _offsetY).HitArea != HitArea.Date)
            {
                _offsetY++;
            }
            // determine X offset of days area 
            while (HitTest(_offsetX, Height / 2).HitArea != HitArea.Date)
            {
                _offsetX++;
            }
            // determine width of a single day box
            _dayBoxWidth = 0;
            DateTime dt1 = HitTest(Width / 2, _offsetY).Time;
            while (HitTest(Width / 2, _offsetY + _dayBoxHeight).Time == dt1)
            {
                _dayBoxHeight++;
            }
            // determine height of a single day box
            _dayBoxWidth = 0;
            DateTime dt2 = HitTest(_offsetX, Height / 2).Time;
            while (HitTest(_offsetX + _dayBoxWidth, Height / 2).Time == dt2)
            {
                _dayBoxWidth++;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        { 
            base.OnPaint(e);
            if (_repaintSelectedDays)
            {
                Graphics graphics = e.Graphics;
                SelectionRange calendarRange = GetDisplayRange(false);
                Rectangle currentDayFrame = new Rectangle(
                    -1, -1, _dayBoxWidth, _dayBoxHeight);
                
                DateTime current = SelectionStart;
                while (current <= SelectionEnd)                
                {
                    Rectangle currentDayRectangle;
                         
                    using (Brush selectionBrush = new SolidBrush(
                        Color.FromArgb(
                            255, System.Drawing.SystemColors.ActiveCaption))) 
                    {                    
                        TimeSpan span = current.Subtract(calendarRange.Start); 
                        int row = span.Days / 7; 
                        int col = span.Days % 7; 
                        currentDayRectangle = new Rectangle(
                            _offsetX + (col + (ShowWeekNumbers ? 1 : 0)) * _dayBoxWidth, 
                            _offsetY + row * _dayBoxHeight, 
                            _dayBoxWidth, 
                            _dayBoxHeight);
                        graphics.FillRectangle(selectionBrush, currentDayRectangle); 
                    }
                    TextRenderer.DrawText(
                        graphics, 
                        current.Day.ToString(), 
                        Font, 
                        currentDayRectangle, 
                        System.Drawing.SystemColors.ActiveCaptionText, 
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                    if (current == this.TodayDate)
                    {
                        currentDayFrame = currentDayRectangle;
                    }
                    current = current.AddDays(1);
                }
                if (currentDayFrame.X > 0)
                {
                    graphics.DrawRectangle(new Pen(
                        new SolidBrush(Color.Red)), currentDayFrame);
                }
                _repaintSelectedDays = false;
            }
        }
    }
