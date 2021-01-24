        private static Chart GetBenchmarkChartStacked(BenchmarkData benchmarkData)
        {
            var chart = new Chart();
            chart.Width = chartWidth;
            chart.Height = chartHeight;
            chart.Palette = chartPalette;
            var seriescounter = 0;
            foreach(var series in benchmarkData.Series)
            {
                seriescounter++;
                var exceededBenchmark = new Series()
                {
                    ChartType = SeriesChartType.StackedColumn,
                    Color = series.Color,
                    BorderColor = series.Color,
                    BorderWidth = 2,
                    CustomProperties = "StackedGroupName=" + series.Name,
                    IsVisibleInLegend = false
                };
                var school = new Series()
                {
                    ChartType = SeriesChartType.StackedColumn,
                    Color = series.Color,
                    BorderColor = series.Color,
                    BorderWidth = 2,
                    CustomProperties = "StackedGroupName=" + series.Name,
                    IsVisibleInLegend = true,
                    Name = series.Name
                };
                var schoolAndBenchmark = new Series()
                {
                    ChartType = SeriesChartType.StackedColumn,
                    Color = series.Color,
                    BorderColor = Color.Gray,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash,
                    CustomProperties = "StackedGroupName=" + series.Name,
                    IsVisibleInLegend = false
                };
                var toReachBenchmark = new Series()
                {
                    ChartType = SeriesChartType.StackedColumn,
                    Color = Color.FromArgb(0, Color.Black),
                    BorderColor = Color.Gray,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash,
                    CustomProperties = "StackedGroupName=" + series.Name,
                    IsVisibleInLegend = false
                };
                if (seriescounter == 1)
                {
                    toReachBenchmark.IsVisibleInLegend = true;
                    toReachBenchmark.Name = "Benchmark";
                }
                for (var i = 0; i < series.DataPoints.Count; i++)
                {
                    var schoolValue = series.DataPoints[i].SchoolValue;
                    var benchmarkValue = series.DataPoints[i].BenchmarkValue;
                    if (schoolValue <= benchmarkValue)
                    {
                        exceededBenchmark.Points.Add(new DataPoint { IsEmpty = true });
                        schoolAndBenchmark.Points.Add(new DataPoint { IsEmpty = true });
                        school.Points.AddY(schoolValue);
                        toReachBenchmark.Points.AddY(benchmarkValue - schoolValue);
                    }
                    else
                    {
                        exceededBenchmark.Points.AddY(schoolValue - benchmarkValue);
                        schoolAndBenchmark.Points.AddY(benchmarkValue);
                        toReachBenchmark.Points.Add(new DataPoint { IsEmpty = true });
                        school.Points.Add(new DataPoint { IsEmpty = true });
                    }
                    exceededBenchmark.Points[i].AxisLabel = series.DataPoints[i].Category;
                    schoolAndBenchmark.Points[i].AxisLabel = series.DataPoints[i].Category;
                    toReachBenchmark.Points[i].AxisLabel = series.DataPoints[i].Category;
                    school.Points[i].AxisLabel = series.DataPoints[i].Category;
                }
                chart.Series.Add(school);
                chart.Series.Add(schoolAndBenchmark);
                chart.Series.Add(exceededBenchmark);
                chart.Series.Add(toReachBenchmark);
            }
            var legend = new Legend("Legend");
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.Font = _graphFont;
            chart.Legends.Add(legend);
            var chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
            chartArea.AxisX.LabelStyle.Font = _graphFont;
            //chartArea.AxisX.Interval = 1;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 1;
            chartArea.AxisY.LabelStyle.Format = "{0:P0}";
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartArea.AxisY.MinorGrid.Enabled = false;
            chartArea.AxisY.MinorTickMark.Enabled = false;
            chart.ChartAreas.Add(chartArea);
            return chart;
        }
