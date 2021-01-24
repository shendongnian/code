    public MainWindow()
    {
        InitializeComponent();
    
        var data = new Dictionary<string, double>
        {
            { "January", 5 },
            { "February", 3 },
            { "March", 5 },
            { "April", 7 },
            { "May", 2 },
            { "June", 11 },
            { "July", 11 },
            { "August", 11 },
            { "September", 11 },
            { "October", 11 },
            { "November", 11 },
            { "December", 12 },
        };
    
        var series = CreateDougnutSeries(data);
        var pie = new RadPieChart { Palette = ChartPalettes.Fluent };
        pie.Series.Add(series);
    
        mainGrid.Children.Add(pie);
    
    }
    
    private DoughnutSeries CreateDougnutSeries(Dictionary<string, double> data)
    {
        var doughnutSeries = new DoughnutSeries
        {
            ShowLabels = true,
            InnerRadiusFactor = 0,
            RadiusFactor = 1
        };
    
        foreach (var point in data)
        {
            doughnutSeries.DataPoints.Add(new PieDataPoint()
            {
                Label = point.Key,
                Value = point.Value,
                OffsetFromCenter = 0.015
            });
        }
    
        return doughnutSeries;
    }
