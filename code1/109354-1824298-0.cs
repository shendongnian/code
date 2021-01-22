    using System.Windows.Forms.DataVisualization.Charting;
    using System.IO;
    ...
        public void GeneratePlot(IList<DataPoint> series, Stream outputStream) {
          using (var ch = new Chart()) {
            ch.ChartAreas.Add(new ChartArea());
            var s = new Series();
            foreach (var pnt in series) s.Points.Add(pnt);
            ch.Series.Add(s);
            ch.SaveImage(outputStream, ChartImageFormat.Jpeg);
          }
        }
