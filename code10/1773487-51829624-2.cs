    private void button1_Click(object sender, EventArgs e)
    {
        ChartArea ca = chart1.ChartAreas[0];
        chart1.Legends[0].Enabled = false;
        int n = (int) numericUpDown1.Value;  // 32 for the above image
        ca.AxisX.Maximum = n ;
        ca.AxisX.Enabled = AxisEnabled.False;
        ca.AxisY.Enabled = AxisEnabled.False;
        ca.AxisX.LabelStyle.Enabled = false;
        ca.AxisY.LabelStyle.Enabled = false;
        for (int j = 1; j < n / 2; j++)
        {
            Series s = chart1.Series.Add("S" + j);
            s.ChartType = SeriesChartType.Polar;
            for (int i = 0; i <= n; i++)
            {
                s.Points.AddXY(i * j , 100);
            }
        }
    }
