    protected override void RenderLabels(IRenderContext rc, OxyRect rect)
        {
            var clip = this.GetClippingRect();
            int m = this.Data.GetLength(0);
            int n = this.Data.GetLength(1);
            double fontSize = (rect.Height / n) * this.LabelFontSize;
            double left = this.X0;
            double right = this.X1;
            double bottom = this.Y0;
            double top = this.Y1;
            var s00 = this.Orientate(this.Transform(left, bottom)); // disorientate
            var s11 = this.Orientate(this.Transform(right, top)); // disorientate
            double sdx = (s11.X - s00.X) / (m - 1);
            double sdy = (s11.Y - s00.Y) / (n - 1);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    var point = this.Orientate(new ScreenPoint(s00.X + (i * sdx), s00.Y + (j * sdy))); // re-orientate
                    var v = GetValue(this.Data, i, j);
                    var color = this.ColorAxis.GetColor(v);
                    var hsv = color.ToHsv();
                    var textColor = hsv[2] > 0.6 ? OxyColors.Black : OxyColors.White;
                    var label = this.Labels[i, j];
                    rc.DrawClippedText(
                        clip,
                        point,
                        label,
                        textColor,
                        this.ActualFont,
                        fontSize,
                        500,
                        0,
                        HorizontalAlignment.Center,
                        VerticalAlignment.Middle);
                }
            }
        }
