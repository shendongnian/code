    private int _intervalMilliseconds;
    private bool _stopUpdating;
    private void UpdateChart()
    {
        // x suvat variables
        double initialsx = Convert.ToDouble(Initialsx.Text);
        double ux = Convert.ToDouble(Initialux.Text);
        double vx = 5;
        double ax = Convert.ToDouble(Initialax.Text);
        // y suvat variables
        double initialsy = Convert.ToDouble(Initialsy.Text);
        double uy = Convert.ToDouble(Initialuy.Text);
        double vy = -93;
        double ay = Convert.ToDouble(Initialay.Text);
        double t = 0.1 * i;
        double sx = initialsx + ux * t + 0.5 * ax * Math.Pow(t, 2);
        double sy = initialsy + uy * t + 0.5 * ay * Math.Pow(t, 2);
        chart1.Series["Curve 1"].Points.AddXY(sx, sy);
        i += 1;
    }
    private async Task StartUpdatingChart()
    {
        while (_stopUpdating == false)
        {
            UpdateChart();
            await Task.Delay(_intervalMilliseconds);
        }
    }
