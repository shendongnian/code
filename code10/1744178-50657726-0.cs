    using System;
    using System.Timers;
    using OxyPlot;
    using OxyPlot.Series;
    
    namespace WpfApp1
    {
        public class MainViewModel
        {
            private LineSeries lineSeries;
            private int count;
    
            public MainViewModel()
            {
                this.MyModel = new PlotModel { Title = "Example 1" };
                //this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
                //this.MyModel.Series.Add(new FunctionSeries(Math.Sin, 0, 10, 0.1, "sin(x)"));
    
                lineSeries = new LineSeries();
                lineSeries.LineStyle = LineStyle.Solid;
                lineSeries.StrokeThickness = 2.0;
                lineSeries.Color = OxyColor.FromRgb(0, 0, 0);
    
                this.MyModel.Series.Add(lineSeries);
    
                Timer timer = new Timer(1000);
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
    
                count = 0;
            }
    
            private void Timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                lineSeries.Points.Add(new DataPoint(count, Math.Pow(count, 2)));
                this.MyModel.InvalidatePlot(true);
    
                count++;
            }
    
            public PlotModel MyModel { get; private set; }
        }
    }
