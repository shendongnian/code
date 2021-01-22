    using System;
    using System.Windows.Forms;
    using System.Drawing;
    class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                e.Graphics.DrawString("My info string...", this.Font, System.Drawing.Brushes.Gray, new System.Drawing.PointF(0, 0));
            }
            else
            {
                e.Graphics.DrawString(Text, this.Font, new SolidBrush(this.ForeColor) , new System.Drawing.PointF(0, 0));
            }
        }
        protected override void OnTextChanged(EventArgs e)
        {
            Invalidate();
            base.OnTextChanged(e);
        }
    }
