    <Window x:Class="DrawChart.SinCosChart"
    	xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    	xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    	Title="Simple Chart" Height="300" Width="300">
    
    	<Viewbox Stretch="Fill">
    		<Border BorderBrush="Black" BorderThickness="1" Margin="5">
    			<Canvas Name="chartCanvas" Width="250" Height="200" ClipToBounds="True"/>
    		</Border>
    	</Viewbox>
    </Window>
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Shapes;
    namespace DrawChart
    {
        public partial class SinCosChart : Window
        {
            private double xmin = 0;
            private double xmax = 6.5;
            private double ymin = -1.1;
            private double ymax = 1.1;
            private Polyline pl;
            public SimpleLineChart()
            {
                InitializeComponent();
                AddChart();
            }
            private void AddChart()
            {
                // Draw sine curve:
                pl = new Polyline();
                pl.Stroke = Brushes.Black;
                for (int i = 0; i < 70; i++)
                {
                    double x = i / 5.0;
                    double y = Math.Sin(x);
                    pl.Points.Add(NormalizePoint(
                        new Point(x, y)));
                }
                chartCanvas.Children.Add(pl);
                // Draw cosine curve:
                pl = new Polyline();
                pl.Stroke = Brushes.Black;
                pl.StrokeDashArray = new DoubleCollection(
                    new double[] { 4, 3 });
                for (int i = 0; i < 70; i++)
                {
                    double x = i / 5.0;
                    double y = Math.Cos(x);
                    pl.Points.Add(NormalizePoint(
                        new Point(x, y)));
                }
                chartCanvas.Children.Add(pl);
            }
            private Point NormalizePoint(Point pt)
            {
                Point result = new Point();
                result.X = (pt.X - xmin) *
                           chartCanvas.Width / (xmax - xmin);
                result.Y = chartCanvas.Height – (pt.Y - ymin) *
                    chartCanvas.Height / (ymax - ymin);
                return result;
            }
        }
    }
    
