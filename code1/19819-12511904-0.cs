        #region Кастомизированное поведение - рамки, активность и т.д.
        private bool isCurrentlyActive = false;
        private bool childControlsAreHandled = false;
        private Pen activeWindowFramePen, inactiveWindowFramePen;
        private Point[] framePoints;
        private void AddControlPaintHandler(Control ctrl)
        {
            ctrl.Paint += DrawWindowFrame;
            if (ctrl.Controls != null)
            {
                foreach (Control childControl in ctrl.Controls)
                {
                    AddControlPaintHandler(childControl);
                }
            }
        }
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if ((this.childControlsAreHandled == false)
                && (WindowFrameType != Forms.WindowFrameType.NoFrame)
                && (this.MdiParent == null))
            {
                RecalculateWindowFramePoints();
                AddControlPaintHandler(this);
                this.childControlsAreHandled = true;
            }
            this.isCurrentlyActive = true;
            if (InactiveWindowOpacity < 1)
            {
                base.Opacity = 1;
            }
            base.Invalidate(true);
        }
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.isCurrentlyActive = false;
            if (InactiveWindowOpacity < 1)
            {
                base.Opacity = InactiveWindowOpacity;
            }
            base.Invalidate(true);
        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            this.framePoints = null;
            RecalculateWindowFramePoints();
            this.Invalidate(true);
        }
        private Pen ActivePen
        {
            get
            {
                if (this.isCurrentlyActive)
                {
                    if (this.activeWindowFramePen == null)
                    {
                        this.activeWindowFramePen = new Pen(Color.FromArgb((int)(WindowFrameOpacity*255), WindowFrameActiveColor), WindowFrameSize * 2);
                    }
                    return this.activeWindowFramePen;
                }
                else
                {
                    if (this.inactiveWindowFramePen == null)
                    {
                        this.inactiveWindowFramePen = new Pen(Color.FromArgb((int)(WindowFrameOpacity*255), WindowFrameInactiveColor), WindowFrameSize * 2);
                    }
                    return this.inactiveWindowFramePen;
                }
            }
        }
        private Point[] RecalculateWindowFramePoints()
        {
            if ((WindowFrameType == Forms.WindowFrameType.AllSides)
                && (this.framePoints != null)
                && (this.framePoints.Length != 5))
            {
                this.framePoints = null;
            }
            if ((WindowFrameType == Forms.WindowFrameType.LeftLine)
                && (this.framePoints != null)
                && (this.framePoints.Length != 2))
            {
                this.framePoints = null;
            }
            if (this.framePoints == null)
            {
                switch (WindowFrameType)
                {
                    case Forms.WindowFrameType.AllSides:
                        this.framePoints = new Point[5]
                        {
                            new Point(this.ClientRectangle.X, this.ClientRectangle.Y),
                            new Point(this.ClientRectangle.X + this.ClientRectangle.Width, this.ClientRectangle.Y),
                            new Point(this.ClientRectangle.X + this.ClientRectangle.Width, this.ClientRectangle.Y + this.ClientRectangle.Height),
                            new Point(this.ClientRectangle.X, this.ClientRectangle.Y + this.ClientRectangle.Height),
                            new Point(this.ClientRectangle.X, this.ClientRectangle.Y)
                        };
                        break;
                    case Forms.WindowFrameType.LeftLine:
                        this.framePoints = new Point[2]
                        {
                            new Point(this.ClientRectangle.X, this.ClientRectangle.Y),
                            new Point(this.ClientRectangle.X, this.ClientRectangle.Y + this.ClientRectangle.Height)
                        };
                        break;
                }
            }
            return this.framePoints;
        }
        private void DrawWindowFrame(object sender, PaintEventArgs e)
        {
            if (WindowFrameType == Forms.WindowFrameType.NoFrame)
            {
                return;
            }
            if ((this.framePoints == null) || (this.framePoints.Length == 0))
            {
                return;
            }
            Control ctrl = (Control)(sender);
            // пересчитаем точки в координатах контрола.
            List<Point> pts = new List<Point>();
            foreach (var p in this.framePoints)
            {
                pts.Add(ctrl.PointToClient(this.PointToScreen(p)));
            }
            e.Graphics.DrawLines(ActivePen, pts.ToArray());
        }
        public static int WindowFrameSize = 2;
        public static WindowFrameType WindowFrameType = Forms.WindowFrameType.NoFrame;
        public static Color WindowFrameActiveColor = Color.YellowGreen;
        public static Color WindowFrameInactiveColor = SystemColors.ControlDark;
        public static double InactiveWindowOpacity = 1.0;
        public static double WindowFrameOpacity = 0.3;
        #endregion
