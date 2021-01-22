    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    
    namespace WpfApplication1
    {
      public partial class MainWindow : Window
      {
        public MainWindow()
        {
          InitializeComponent();      
        }    
    
        private Point _startPoint;
        private bool _dragging = false;
    
        private void Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {         
          if (dragButton.CaptureMouse())
          {        
            _startPoint = e.GetPosition(null);
            _dragging = true;        
          }
        }
    
        private void Canvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
          if (_dragging)
          {        
            Point newPoint = e.GetPosition(null);
            double dx = newPoint.X - _startPoint.X;
            double dy = newPoint.Y - _startPoint.Y;
    
            Canvas.SetLeft(dragButton, Canvas.GetLeft(dragButton) + dx);
            Canvas.SetTop(dragButton, Canvas.GetTop(dragButton) + dy);
            _startPoint = newPoint;
          }
        }
    
        private void Canvas_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
          if (_dragging)
          {        
            _dragging = false;
            dragButton.ReleaseMouseCapture();
          }
        }    
      }
    }
