    public Form1()
    {
      InitializeComponent();
      DateTime startTime = DateTime.MinValue.Add(new TimeSpan(8, 25, 0));
      DateTime endTime   = DateTime.MinValue.Add(new TimeSpan(10, 45, 0));
      chart1.Series["RUN"].Points.AddXY(
        1,
        startTime,
        endTime);
      startTime = DateTime.MinValue.Add(new TimeSpan(10, 45, 0));
      endTime = DateTime.MinValue.Add(new TimeSpan(12, 45, 0));
      chart1.Series["WAIT"].Points.AddXY(
        1,
        startTime,
        endTime);
      startTime = DateTime.MinValue.Add(new TimeSpan(12, 45, 0));
      endTime = DateTime.MinValue.Add(new TimeSpan(20, 0, 0));
      chart1.Series["OFF"].Points.AddXY(
        1,
        startTime,
        endTime);
      chart1.Series["RUN"].Points[0].AxisLabel = "Machine 1";
      chart1.Series["RUN"]["DrawSideBySide"] = "false";
      chart1.ChartAreas["Default"].AxisY.Interval = 60; // Show 1 hour intervals.
      chart1.ChartAreas["Default"].AxisY.IntervalType = DateTimeIntervalType.Minutes;
      chart1.ChartAreas["Default"].AxisY.LabelStyle.Format = "HH:mm"; // Set the format to show hours and minutes.
    }
