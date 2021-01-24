           foreach (string product in products)
            {
                string seriesName = product;
                chart1.Series.Add(seriesName);
                DataTable dtprod = new DataTable();
                dtprod = dt.Select("product= '" + product + "'").CopyToDataTable();
                chart1.Series[seriesName].ChartType = SeriesChartType.Point;
                chart1.Series[seriesName].YValueMembers = "VALUE";
                chart1.Series[seriesName].XValueMember = "DATE";
                chart1.Series[seriesName].Points.DataBindXY(dtprod.Rows,"DATE", dtprod.Rows, "VALUE");
                chart1.Series[seriesName].XValueType = ChartValueType.DateTime;
                chart1.Series[seriesName].MarkerSize = 10;
            }
