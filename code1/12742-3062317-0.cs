    /// <summary>
    /// When Visual Styles are enabled on Windows XP, the MonthCalendar.SelectionRange
    /// does not paint correctly when more than one date is selected.
    /// See: http://msdn.microsoft.com/en-us/library/5d1acks5(VS.80).aspx
    /// "Additionally, if you enable visual styles on some controls, the control might display incorrectly
    /// in certain situations. These include the MonthCalendar control with a selection range set...
    /// This class fixes that problem.
    /// </summary>
    /// <remarks>Author: Mark Cranness - PatronBase Limited</remarks>
    public class FixVisualStylesMonthCalendar : System.Windows.Forms.MonthCalendar {
    
        /// <summary>
        /// The width of a single cell (date) in the calendar.
        /// </summary>
        private int dayCellWidth;
        /// <summary>
        /// The height of a single cell (date) in the calendar.
        /// </summary>
        private int dayCellHeight;
    
        /// <summary>
        /// The calendar first day of the week actually used.
        /// </summary>
        private DayOfWeek calendarFirstDayOfWeek;
    
        /// <summary>
        /// Only repaint when VisualStyles enabled on Windows XP.
        /// </summary>
        private bool repaintSelectionRange = false;
    
        /// <summary>
        /// A MonthCalendar class that fixes SelectionRange painting problems 
        /// on Windows XP when Visual Styles is enabled.
        /// </summary>
        public FixVisualStylesMonthCalendar() {
    
            if (Application.RenderWithVisualStyles
                    && Environment.OSVersion.Version < new Version(6, 0)) {
    
                // If Visual Styles are enabled, and XP, then fix-up the painting of SelectionRange
                this.repaintSelectionRange = true;
                this.OnSizeChanged(this, EventArgs.Empty);
                this.SizeChanged += new EventHandler(this.OnSizeChanged);
    
            }
        }
    
        /// <summary>
        /// The WM_PAINT message is sent to make a request to paint a portion of a window.
        /// </summary>
        public const int WM_PAINT = 0x000F;
    
        /// <summary>
        /// Override WM_PAINT to repaint the selection range.
        /// </summary>
        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT
                    && !this.DesignMode
                    && this.repaintSelectionRange) {
                // MonthCalendar is ControlStyles.UserPaint=false => Paint event is not raised
                this.RepaintSelectionRange(ref m);
            }
        }
    
        /// <summary>
        /// Repaint the SelectionRange.
        /// </summary>
        private void RepaintSelectionRange(ref Message m) {
    
            using (Graphics graphics = this.CreateGraphics())
            using (Brush backBrush
                    = new SolidBrush(graphics.GetNearestColor(this.BackColor)))
            using (Brush selectionBrush
                    = new SolidBrush(graphics.GetNearestColor(SystemColors.ActiveCaption))) {
    
                Rectangle todayFrame = Rectangle.Empty;
    
                // For each day in SelectionRange...
                for (DateTime selectionDate = this.SelectionStart;
                        selectionDate <= this.SelectionEnd;
                        selectionDate = selectionDate.AddDays(1)) {
    
                    Rectangle selectionDayRectangle = this.GetSelectionDayRectangle(selectionDate);
                    if (selectionDayRectangle.IsEmpty) continue;
    
                    if (selectionDate == this.TodayDate) {
                        todayFrame = selectionDayRectangle;
                    }
    
                    // Paint as 'selected' a little smaller than the whole rectangle
                    Rectangle highlightRectangle = Rectangle.Inflate(selectionDayRectangle, 0, -2);
                    if (selectionDate == this.SelectionStart) {
                        highlightRectangle.X += 2;
                        highlightRectangle.Width -= 2;
                    } else if (selectionDate == this.SelectionEnd) {
                        highlightRectangle.Width -= 2;
                    }
    
                    // Paint background, selection and day-of-month text
                    graphics.FillRectangle(backBrush, selectionDayRectangle);
                    graphics.FillRectangle(selectionBrush, highlightRectangle);
                    TextRenderer.DrawText(
                        graphics,
                        selectionDate.Day.ToString(),
                        this.Font,
                        selectionDayRectangle,
                        SystemColors.ActiveCaptionText,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    
                }
    
                if (this.ShowTodayCircle && !todayFrame.IsEmpty) {
                    // Redraw the ShowTodayCircle (square) that we painted over above
                    using (Pen redPen = new Pen(Color.Red)) {
                        todayFrame.Width--;
                        todayFrame.Height--;
                        graphics.DrawRectangle(redPen, todayFrame);
                    }
                }
    
            }
        }
    
        /// <summary>
        /// Gets a graphics Rectangle for the area corresponding to a single date on the calendar.
        /// </summary>
        private Rectangle GetSelectionDayRectangle(DateTime selectionDate) {
    
            Point monthDateAreaLocation = this.GetMonthDateAreaLocation(selectionDate);
            if (monthDateAreaLocation.IsEmpty) return Rectangle.Empty;
    
            DayOfWeek monthFirstDayOfWeek = (new DateTime(selectionDate.Year, selectionDate.Month, 1)).DayOfWeek;
            int dayOfWeekAdjust = (int)monthFirstDayOfWeek - (int)this.calendarFirstDayOfWeek;
            if (dayOfWeekAdjust < 0) dayOfWeekAdjust += 7;
            int row = (selectionDate.Day - 1 + dayOfWeekAdjust) / 7;
            int col = (selectionDate.Day - 1 + dayOfWeekAdjust) % 7;
    
            return new Rectangle(
                monthDateAreaLocation.X + col * this.dayCellWidth,
                monthDateAreaLocation.Y + row * this.dayCellHeight,
                this.dayCellWidth,
                this.dayCellHeight);
    
        }
    
        /// <summary>
        /// Cached calendar location from the last lookup: date month.
        /// </summary>
        private DateTime previousSelectionDate = DateTime.MinValue;
        /// <summary>
        /// Cached calendar location from the last lookup: month date area location.
        /// </summary>
        private Point previousMonthDateAreaLocation;
    
        /// <summary>
        /// Gets the graphics location (x,y point) of the top left of the
        /// calendar date area for the month containing the specified date.
        /// </summary>
        private Point GetMonthDateAreaLocation(DateTime selectionDate) {
    
            if (selectionDate.Year == this.previousSelectionDate.Year
                    && selectionDate.Month == this.previousSelectionDate.Month) {
    
                // Use previously cached lookup
                return this.previousMonthDateAreaLocation;
    
            } else {
    
                // Assume the worst (Error: empty)
                this.previousSelectionDate = selectionDate;
                Point monthDateAreaLocation = this.previousMonthDateAreaLocation = Point.Empty;
    
                Point monthDataAreaPoint = this.GetMonthDateAreaMiddle(selectionDate);
                if (monthDataAreaPoint.IsEmpty) return Point.Empty;
    
                // Move left from the middle to find the left edge of the Date area
                monthDateAreaLocation.X = monthDataAreaPoint.X--;
                HitTestInfo hitInfo1, hitInfo2;
                while ((hitInfo1 = this.HitTest(monthDataAreaPoint.X, monthDataAreaPoint.Y))
                        .HitArea == HitArea.Date
                        && hitInfo1.Time.Month == selectionDate.Month
                    || (hitInfo2 = this.HitTest(monthDataAreaPoint.X, monthDataAreaPoint.Y + this.dayCellHeight))
                        .HitArea == HitArea.Date
                        && hitInfo2.Time.Month == selectionDate.Month) {
                    monthDateAreaLocation.X = monthDataAreaPoint.X--;
                    if (monthDateAreaLocation.X < 0) return Point.Empty; // Error: bail
                }
    
                // Move up from the last column to find the top edge of the Date area
                int monthLastDayOfWeekX = monthDateAreaLocation.X + (this.dayCellWidth * 7 * 13) / 14;
                monthDateAreaLocation.Y = monthDataAreaPoint.Y--;
                while (this.HitTest(monthLastDayOfWeekX, monthDataAreaPoint.Y).HitArea == HitArea.Date) {
                    monthDateAreaLocation.Y = monthDataAreaPoint.Y--;
                    if (monthDateAreaLocation.Y < 0) return Point.Empty; // Error: bail
                }
    
                // Got it
                this.previousMonthDateAreaLocation = monthDateAreaLocation;
                return monthDateAreaLocation;
    
            }
        }
    
        /// <summary>
        /// Paranoid fudge/wobble of the GetMonthDateAreaMiddle in case 
        /// our first estimate to hit the month misses.
        /// (Needed? perhaps not.)
        /// </summary>
        private static Point[] searchSpiral = new Point[] {
            new Point( 0, 0),
            new Point(-1,+1),
            new Point(+1,+1),
            new Point(+1,-1),
            new Point(-1,-1),
            new Point(-2,+2),
            new Point(+2,+2),
            new Point(+2,-2),
            new Point(-2,-2)
        };
    
        /// <summary>
        /// Gets a point somewhere inside the calendar date area of
        /// the month containing the given selection date.
        /// </summary>
        /// <remarks>The point returned will be HitArea.Date, and match the year and
        /// month of the selection date; otherwise it will be Point.Empty.</remarks>
        private Point GetMonthDateAreaMiddle(DateTime selectionDate) {
    
            // Iterate over all displayed months, and a search spiral (needed? perhaps not)
            for (int dimX = 1; dimX <= this.CalendarDimensions.Width; dimX++) {
                for (int dimY = 1; dimY <= this.CalendarDimensions.Height; dimY++) {
                    foreach (Point search in searchSpiral) {
    
                        Point monthDateAreaMiddle = new Point(
                            ((dimX - 1) * 2 + 1) * this.Width / (2 * this.CalendarDimensions.Width)
                                + this.dayCellWidth * search.X,
                            ((dimY - 1) * 2 + 1) * this.Height / (2 * this.CalendarDimensions.Height)
                                + this.dayCellHeight * search.Y);
                        HitTestInfo hitInfo = this.HitTest(monthDateAreaMiddle);
                        if (hitInfo.HitArea == HitArea.Date) {
                            // Got the Date Area of the month
                            if (hitInfo.Time.Year == selectionDate.Year
                                    && hitInfo.Time.Month == selectionDate.Month) {
                                // For the correct month
                                return monthDateAreaMiddle;
                            } else {
                                // Keep looking in the other months
                                break;
                            }
                        }
    
                    }
                }
            }
            return Point.Empty; // Error: not found
    
        }
    
        /// <summary>
        /// When this MonthCalendar is resized, recalculate the size of a 
        /// </summary>
        private void OnSizeChanged(object sender, EventArgs e) {
    
            // Discard previous cached Month Area Location
            this.previousSelectionDate = DateTime.MinValue;
            this.dayCellWidth = this.dayCellHeight = 0;
    
            // Without this, the repaint sometimes does not happen...
            this.Invalidate();
    
            // Determine Y offset of days area
            int middle = this.Width / (2 * this.CalendarDimensions.Width);
            int dateAreaTop = 0;
            while (this.HitTest(middle, dateAreaTop).HitArea != HitArea.PrevMonthDate
                    && this.HitTest(middle, dateAreaTop).HitArea != HitArea.Date) {
                dateAreaTop++;
                if (dateAreaTop > this.ClientSize.Height) return; // Error: bail
            }
    
            // Determine height of a single day box
            int dayCellHeight = 1;
            DateTime dayCellTime = this.HitTest(middle, dateAreaTop).Time;
            while (this.HitTest(middle, dateAreaTop + dayCellHeight).Time == dayCellTime) {
                dayCellHeight++;
            }
    
            // Determine X offset of days area
            middle = this.Height / (2 * this.CalendarDimensions.Height);
            int dateAreaLeft = 0;
            while (this.HitTest(dateAreaLeft, middle).HitArea != HitArea.Date) {
                dateAreaLeft++;
                if (dateAreaLeft > this.ClientSize.Width) return; // Error: bail
            }
    
            // Determine width of a single day box
            int dayCellWidth = 1;
            dayCellTime = this.HitTest(dateAreaLeft, middle).Time;
            while (this.HitTest(dateAreaLeft + dayCellWidth, middle).Time == dayCellTime) {
                dayCellWidth++;
            }
    
            // Record day box size and actual first day of the month used
            this.calendarFirstDayOfWeek = dayCellTime.DayOfWeek;
            this.dayCellWidth = dayCellWidth;
            this.dayCellHeight = dayCellHeight;
    
        }
    
    }
