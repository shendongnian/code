    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace FreeformDrawing
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private Polygon polygon;
            private bool isDrawing = false;
    
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                if (!isDrawing)
                {
                    isDrawing = true;
    
                    polygon = new Polygon()
                    {
                        Stroke = Brushes.Black,
                        StrokeThickness = 1,
                        StrokeMiterLimit = 1,
                        StrokeLineJoin = PenLineJoin.Round,
                        StrokeStartLineCap = PenLineCap.Round,
                        StrokeEndLineCap = PenLineCap.Round
                    };
    
                    AddPoint(e.GetPosition(DrawingCanvas));
                    DrawingCanvas.Children.Add(polygon);
                }
            }
    
            public void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
            {
                isDrawing = false;
    
                if (polygon != null)
                {
                    polygon.Points.Add(polygon.Points.First());
                    polygon.Fill = Brushes.Yellow;
                }
            }
    
            public void Window_MouseMove(object sender, MouseEventArgs e)
            {
                if (isDrawing)
                {
                    AddPoint(e.GetPosition(DrawingCanvas));
                }
            }
    
            private void AddPoint(Point value)
            {
                if (value.X < (DrawingCanvas.ActualWidth - 1)
                && value.Y < (DrawingCanvas.ActualHeight - 1))
                {
                    polygon.Points.Add(value);
                }
            }
        }
    }
