        class DragOrderedDataGridView : System.Windows.Forms.DataGridView
    {
        public delegate void RowDroppedEventHangler(object source, DataGridViewRow sourceRow, DataGridViewRow destinationRow);
        public event RowDroppedEventHangler RowDropped;
        bool bDragging = false;
        System.Windows.Forms.DataGridView.HitTestInfo hti = null;
        System.Threading.Timer scrollTimer = null;
        delegate void SetScrollDelegate(int value);
        public bool AllowDragOrdering { get; set; }
        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            if (AllowDragOrdering)
            {
                DataGridView.HitTestInfo hti = this.HitTest(e.X, e.Y);
                if (hti.RowIndex != -1
                 && hti.RowIndex != this.NewRowIndex
                 && e.Button == MouseButtons.Left)
                {
                    bDragging = true;
                }
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (bDragging && e.Button == MouseButtons.Left)
            {
                DataGridView.HitTestInfo newhti = this.HitTest(e.X, e.Y);
                if (hti != null && hti.RowIndex != newhti.RowIndex)
                {
                    System.Diagnostics.Debug.WriteLine("invalidating " + hti.RowIndex.ToString());
                    Invalidate();
                }
                hti = newhti;
                System.Diagnostics.Debug.WriteLine(string.Format("{0:000} {1}  ", hti.RowIndex, e.Location));
                Point clientPoint = this.PointToClient(e.Location);
                System.Diagnostics.Debug.WriteLine(e.Location + "  " + this.Bounds.Size);
                if (scrollTimer == null
                && ShouldScrollDown(e.Location))
                {
                    //
                    // enable the timer to scroll the screen
                    //
                    scrollTimer = new System.Threading.Timer(new System.Threading.TimerCallback(TimerScroll), 1, 0, 250);
                }
                if (scrollTimer == null
                && ShouldScrollUp(e.Location))
                {
                    scrollTimer = new System.Threading.Timer(new System.Threading.TimerCallback(TimerScroll), -1, 0, 250);
                }
            }
            else
            {
                bDragging = false;
            }
            if (!(ShouldScrollUp(e.Location) || ShouldScrollDown(e.Location)))
            {
                StopAutoScrolling();
            }
            base.OnMouseMove(e);
        }
        bool ShouldScrollUp(Point location)
        {
            return location.Y > this.ColumnHeadersHeight
                && location.Y < this.ColumnHeadersHeight + 15
                && location.X >= 0
                && location.X <= this.Bounds.Width;
        }
        bool ShouldScrollDown(Point location)
        {
            return location.Y > this.Bounds.Height - 15
                && location.Y < this.Bounds.Height
                && location.X >= 0
                && location.X <= this.Bounds.Width;
        }
        void StopAutoScrolling()
        {
            if (scrollTimer != null)
            {
                //
                // disable the timer to scroll the screen
                // 
                scrollTimer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
                scrollTimer = null;
            }
        }
        void TimerScroll(object state)
        {
            SetScrollBar((int)state);
        }
        bool scrolling = false;
        void SetScrollBar(int direction)
        {
            if (scrolling)
            {
                return;
            }
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(SetScrollBar), new object[] {direction});
            }
            else
            {
                scrolling = true;
                if (0 < direction)
                {
                    if (this.FirstDisplayedScrollingRowIndex < this.Rows.Count - 1)
                    {
                        this.FirstDisplayedScrollingRowIndex++;
                    }
                }
                else
                {
                    if (this.FirstDisplayedScrollingRowIndex > 0)
                    {
                        this.FirstDisplayedScrollingRowIndex--;
                    }
                }
                scrolling = false;
            }
        }
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            bDragging = false;
            HitTestInfo livehti = hti;
            hti = null;
            if (RowDropped != null
             && livehti != null
             && livehti.RowIndex != -1
             && this.CurrentRow.Index != livehti.RowIndex)
            {
                RowDropped(this, this.CurrentRow, this.Rows[livehti.RowIndex]);
            }
            StopAutoScrolling();
            Invalidate();
            base.OnMouseUp(e);
        }
        protected override void OnCellPainting(System.Windows.Forms.DataGridViewCellPaintingEventArgs e)
        {
            if (bDragging && hti != null && hti.RowIndex != -1
             && e.RowIndex == hti.RowIndex)
            {
                //
                // draw the indicator
                //
                Pen p = new Pen(Color.FromArgb(0, 0, 215));
                p.Width = 4;
                e.Graphics.DrawLine(p, e.CellBounds.Left, e.CellBounds.Top, e.CellBounds.Right, e.CellBounds.Top);
            }
            base.OnCellPainting(e);
        }
    }
