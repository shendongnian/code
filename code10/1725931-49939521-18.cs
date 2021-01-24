    ChartArea ca = chart.ChartAreas[0];
    ca.RecalculateAxesScale();
    float cah = ca.Position.Height;
    float iph = ca.InnerPlotPosition.Height;
    float h = chart3.ClientSize.Height * cah / 100f * iph / 100f;
    int mh = (int)(h / s.Points.Count);
