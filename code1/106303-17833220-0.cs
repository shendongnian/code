    public partial class TextBoxOwnerDraw : Panel
    {
        private TextBox MyTextBox;
        private int cornerRadius = 1;
        private Color borderColor = Color.Black;
        private int borderSize = 1;
        private Size preferredSize = new Size(120, 25); // Use 25 for height, so it sits in the middle
        /// <summary>
        /// Access the textbox
        /// </summary>
        public TextBox TextBox
        {
            get { return MyTextBox; }
        }
        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                RestyleTextBox();
                this.Invalidate();
            }
        }
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                RestyleTextBox();
                this.Invalidate();
            }
        }
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                borderSize = value;
                RestyleTextBox();
                this.Invalidate();
            }
        }
        public Size PrefSize
        {
            get { return preferredSize; }
            set
            {
                preferredSize = value;
                RestyleTextBox();
                this.Invalidate();
            }
        }
        public TextBoxOwnerDraw()
        {
            MyTextBox = new TextBox();
            this.Controls.Add(MyTextBox);
            RestyleTextBox();
        }
        private void RestyleTextBox()
        {
            double TopPos = Math.Floor(((double)this.preferredSize.Height / 2) - ((double)MyTextBox.Height / 2));
            MyTextBox.BackColor = Color.White;
            MyTextBox.BorderStyle = BorderStyle.None;
            MyTextBox.Multiline = false;
            MyTextBox.Top = (int)TopPos;
            MyTextBox.Left = this.BorderSize;
            MyTextBox.Width = preferredSize.Width - (this.BorderSize * 2);
            this.Height = MyTextBox.Height + (this.BorderSize * 2); // Will be ignored, but if you use elsewhere
            this.Width = preferredSize.Width;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (cornerRadius > 0 && borderSize > 0)
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle cRect = this.ClientRectangle;
                Rectangle safeRect = new Rectangle(cRect.X, cRect.Y, cRect.Width - this.BorderSize, cRect.Height - this.BorderSize);
                // Background color
                using (Brush bgBrush = new SolidBrush(MyTextBox.BackColor))
                {
                    DrawRoundRect(g, bgBrush, safeRect, (float)this.CornerRadius);
                }
                // Border
                using (Pen borderPen = new Pen(this.BorderColor, (float)this.BorderSize))
                {
                    DrawRoundRect(g, borderPen, safeRect, (float)this.CornerRadius);
                }
            }
            base.OnPaint(e);
        }
        #region Private Methods
        private GraphicsPath getRoundRect(int x, int y, int width, int height, float radius)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddLine(x + radius, y, x + width - (radius * 2), y); // Line
            gp.AddArc(x + width - (radius * 2), y, radius * 2, radius * 2, 270, 90); // Corner (Top Right)
            gp.AddLine(x + width, y + radius, x + width, y + height - (radius * 2)); // Line
            gp.AddArc(x + width - (radius * 2), y + height - (radius * 2), radius * 2, radius * 2, 0, 90); // Corner (Bottom Right)
            gp.AddLine(x + width - (radius * 2), y + height, x + radius, y + height); // Line
            gp.AddArc(x, y + height - (radius * 2), radius * 2, radius * 2, 90, 90); // Corner (Bottom Left)
            gp.AddLine(x, y + height - (radius * 2), x, y + radius); // Line
            gp.AddArc(x, y, radius * 2, radius * 2, 180, 90); // Corner (Top Left)
            gp.CloseFigure();
            return gp;
        }
        private void DrawRoundRect(Graphics g, Pen p, Rectangle rect, float radius)
        {
            GraphicsPath gp = getRoundRect(rect.X, rect.Y, rect.Width, rect.Height, radius);
            g.DrawPath(p, gp);
            gp.Dispose();
        }
        private void DrawRoundRect(Graphics g, Pen p, int x, int y, int width, int height, float radius)
        {
            GraphicsPath gp = getRoundRect(x, y, width, height, radius);
            g.DrawPath(p, gp);
            gp.Dispose();
        }
        private void DrawRoundRect(Graphics g, Brush b, int x, int y, int width, int height, float radius)
        {
            GraphicsPath gp = getRoundRect(x, y, width, height, radius);
            g.FillPath(b, gp);
            gp.Dispose();
        }
        private void DrawRoundRect(Graphics g, Brush b, Rectangle rect, float radius)
        {
            GraphicsPath gp = getRoundRect(rect.X, rect.Y, rect.Width, rect.Height, radius);
            g.FillPath(b, gp);
            gp.Dispose();
        }
        #endregion
    }
