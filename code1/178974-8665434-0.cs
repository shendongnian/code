        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> employees = new Dictionary<int, string>();
            employees.Add(10, "Denys");
            employees.Add(20, "Botse");
            employees.Add(30, "Matthew");
            Chart1.Series[0].ChartType = SeriesChartType.Bar;
            foreach (KeyValuePair<int, string> employee in employees)
            {
                Chart1.Series[0].Points.AddXY(employee.Value, employee.Key);
            }
        }
