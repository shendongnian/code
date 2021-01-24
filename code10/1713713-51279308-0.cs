    protected OxyRect GetClippingRect()
        {
            double minX,minY,maxX,maxY;
            if (this.PlotModel.AxisSizeIsClippingArea)
            {
                minX = Math.Min(this.XAxis.ScreenMin.X, this.XAxis.ScreenMax.X);
                minY = Math.Min(this.YAxis.ScreenMin.Y, this.YAxis.ScreenMax.Y);
                maxX = Math.Max(this.XAxis.ScreenMin.X, this.XAxis.ScreenMax.X);
                maxY = Math.Max(this.YAxis.ScreenMin.Y, this.YAxis.ScreenMax.Y);
            }
            else
            {
                var yAxes = this.PlotModel.Axes.Where(ax => ax.Position == AxisPosition.Left || ax.Position == AxisPosition.Right);
                var xAxes = this.PlotModel.Axes.Where(ax => ax.Position == AxisPosition.Bottom || ax.Position == AxisPosition.Top);
                maxY = yAxes.Max(ax => Math.Max(ax.ScreenMin.Y, ax.ScreenMax.Y));
                minY = yAxes.Min(ax => Math.Min(ax.ScreenMin.Y, ax.ScreenMax.Y));
                maxX = xAxes.Max(ax => Math.Max(ax.ScreenMax.X, ax.ScreenMax.X));
                minX = xAxes.Min(ax => Math.Min(ax.ScreenMin.X, ax.ScreenMin.X));
            }
            return new OxyRect(minX, minY, maxX - minX, maxY - minY);
        }
