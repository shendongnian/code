    List<Series> ListSeries = new List<Series>();
           foreach(Series series in chart1.Series)
            {
                Series subSeries = new Series();
                series.Points.Skip(BeginIndex).Take(EndIndex - BeginIndex).ToList().ForEach(subSeries.Points.Add);
                ListSeries.Add(subSeries);
            }
            chart1.Series.Clear();
            foreach (Series series in ListSeries)
            {
                series.ChartType = SeriesChartType.Line;
                chart1.Series.Add(series);
            }
        }
