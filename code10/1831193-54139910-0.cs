    using System.Drawing;
    using System.Drawing.Drawing2D;
 
    float GaugeValue = 88.0f;
    float GaugeSweepAngle = 270.0f;
    float GaugeStartAngle = 135.0F;
    private void Canvas_Paint(object sender, PaintEventArgs e)
    {
        Control canvas = sender as Control;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle outerRectangle = new Rectangle(10, 10, 180, 180);
        Rectangle innerRectangle = new Rectangle(30, 30, 140, 140);
        Rectangle blendRectangle = new Rectangle(10, 10, 180, 160);
        PointF innerCenter = new PointF(outerRectangle.Left + (outerRectangle.Width / 2),
                                        outerRectangle.Top + (outerRectangle.Height / 2));
        float gaugeLength = (outerRectangle.Width / 2) - 2;
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddPie(outerRectangle, GaugeStartAngle, GaugeSweepAngle);
            path.AddPie(innerRectangle, GaugeStartAngle, GaugeSweepAngle);
            innerRectangle.Inflate(-1, -1);
            using (Pen pen = new Pen(Color.White, 3f))
            using (SolidBrush backgroundbrush = new SolidBrush(canvas.BackColor))
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(blendRectangle,
                   Color.Green, Color.Red, LinearGradientMode.ForwardDiagonal))
            {
                Blend blend = new Blend()
                {
                    Factors = new[] { 0.0f, 0.0f, 0.1f, 0.3f, 0.7f, 1.0f },
                    Positions = new[] { 0.0f, 0.2f, 0.4f, 0.6f, 0.8f, 1.0f }
                };
                gradientBrush.Blend = blend;
                e.Graphics.FillPath(gradientBrush, path);
                e.Graphics.DrawPath(pen, path);
                e.Graphics.FillEllipse(backgroundbrush, innerRectangle);
                using (StringFormat format = new StringFormat())
                {
                    format.Alignment = StringAlignment.Center;
                    format.LineAlignment = StringAlignment.Center;
                    innerRectangle.Location = new Point(innerRectangle.X, innerRectangle.Y + canvas.Font.Height);
                    e.Graphics.DrawString(GaugeValue.ToString() + "%", canvas.Font, Brushes.White, innerRectangle, format);
                }
                using (Matrix matrix = new Matrix())
                {
                    matrix.RotateAt(GaugeStartAngle + 90 + (GaugeValue * (GaugeSweepAngle / 100)), innerCenter);
                    e.Graphics.Transform = matrix;
                    e.Graphics.DrawLine(pen, innerCenter, new PointF(innerCenter.X, innerCenter.Y - gaugeLength));
                    e.Graphics.ResetTransform();
                }
            }
        }
    }
 
    private void tbarSpeed_Scroll(object sender, EventArgs e)
    {
        GaugeValue = tbarSpeed.Value;
        Canvas.Invalidate();
    }
 
