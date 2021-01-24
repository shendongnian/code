    private void chart_AnnotationPositionChanging(object sender, 
                                                  AnnotationPositionChangingEventArgs e)
    {
        chart.Invalidate();
    }
    private void chart_AnnotationPositionChanged(object sender, EventArgs e)
    {
        chart.Invalidate();
    }
