            private void xrChart1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrChart1.Series["Ligne Assemblage"].Points.Add(new DevExpress.XtraCharts.SeriesPoint("Ligne Assemblage", txtAssembly.Text));
            xrChart1.Series["Ligne Soudage"].Points.Add(new DevExpress.XtraCharts.SeriesPoint("Ligne Soudage", txtWelding.Text));
            xrChart1.Series["Ligne Peinture"].Points.Add(new DevExpress.XtraCharts.SeriesPoint("Ligne Peinture", txtPaint.Text));
        }
