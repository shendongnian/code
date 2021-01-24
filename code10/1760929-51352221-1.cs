    private void ContentView_SizeChanged(object sender, EventArgs e)
    {
        double fontSize = measureViewBox.Width;
        myLabel.FontSize = fontSize;
        SizeRequest measurement = myLabel.Measure(double.PositiveInfinity, double.PositiveInfinity);
        while (measurement.Request.Width >= measureViewBox.Width)
        {
            fontSize -= 2;
            myLabel.FontSize = fontSize;
            measurement = myLabel.Measure(double.PositiveInfinity, double.PositiveInfinity);
        }
    }
