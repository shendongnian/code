    protected void Page_Load(object sender, EventArgs e)
        {
            GetFreeSpace();
            GetTotalData();
            usedSpace = totalSpace - freeSpace;
            // Display 3D Pie Chart
            Chart1.Series[0].ChartType = SeriesChartType.Pie;
            Chart1.Series[0]["PieLabelStyle"] = "Inside";
            Chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            // Display a Title
            Chart1.Titles.Add("Show Space");
            // Add Data to Display
            string[] xValues = { "Used Space","Free Space" };
            double[] yValues = { usedSpace,freeSpace};
            Chart1.Series[0].Points.DataBindXY(xValues, yValues);
            // Call Out The Letter "Free Space"
            Chart1.Series[0].Points[1]["Exploded"] = "true";
            // Display a Legend
            Chart1.Legends.Add(new Legend("Alphabet"));
            Chart1.Legends["Alphabet"].Title = "Letters";
            Chart1.Series[0].Legend = "Alphabet";
        }
