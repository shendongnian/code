    string selectedSeries = "";     // store a class-scoped reference
    
    private void plot.MouseMove(object sender, MouseEventArgs e)
    {
        HitTestResult result = plot.HitTest(e.X, e.Y);
        if (result != null && result.Object != null && result.ChartElementType == ChartElementType.LegendItem)
        {
            string selseries = result.Series.Name;
    
            // store a reference to what we are changing:
            selectedSeries = selseries;
    
            plot.Series[selseries].MarkerBorderWidth = 3;
            plot.Series[selseries].MarkerSize = 11;
            plot.Series[selseries].MarkerBorderColor = Color.Black;
        }
        else
        {
            // if we clear the selection here, then we are clearing the selection
            // whenever we move off the legend item... that was one of your use cases
            // you could also do something similar in a mouse click event to cover your other use case.
    
            if (selectedSeries != "")
            {
                plot.Series[selectedSeries].MarkerBorderWidth = 1; // set these to default value
                plot.Series[selectedseries].MarkerSize = 5;
                plot.Series[selectedseries].MarkerBorderColor = Color.Green;
                selectedSeries = ""; // reset selection
            }
        }
    }
