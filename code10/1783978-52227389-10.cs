    void setCenterAnnotation(Chart chart, ChartArea ca, 
                             DataPoint dp1, DataPoint dp2, string lbl)
    {
            TextAnnotation ta = new TextAnnotation();
            ta.Alignment = ContentAlignment.BottomCenter;
            ta.AnchorAlignment = ContentAlignment.TopCenter;
            DataPoint dp = dp1.YValues[0] > dp2.YValues[0] ? dp1 : dp2;
            ta.Height = 0.36f;
            ta.AxisX = ca.AxisX;
            ta.AxisY = ca.AxisY;
            ta.AnchorDataPoint = dp;
            ta.AnchorX = dp1.XValue;
            ta.Text =  lbl;
            chart.Annotations.Add(ta);
    }
