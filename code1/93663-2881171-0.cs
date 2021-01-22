    public class StatusProgressBar : ProgressBar
    {
        const int WmPaint = 15;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WmPaint:
                    using (var graphics = Graphics.FromHwnd(Handle))
                    {
                        var textSize = graphics.MeasureString(Text, Font);
                        using(var textBrush = new SolidBrush(ForeColor))
                            graphics.DrawString(Text, Font, textBrush, (Width / 2) - (textSize.Width / 2), (Height / 2) - (textSize.Height / 2));
                    }
                    break;
            }
        }
    }
