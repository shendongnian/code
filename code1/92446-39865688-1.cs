     public sealed partial class DragUserControl : UserControl
        {
            MovingObject;
            double FirstXPos, FirstYPos;
    
            public DragUserControl()
            {
                InitializeComponent();
            }
    
           private void Ellipse_PointerPressed(object sender, PointerRoutedEventArgs e)
            {
                this.MovingObject = this;
    
                FirstXPos = e.GetCurrentPoint(MovingObject as Control).Position.X;
                FirstYPos = e.GetCurrentPoint(MovingObject as Control).Position.Y;
    
                Canvas canvas = this.Parent as Canvas;
                if (canvas != null)
                {
                    canvas.PointerMoved += Canvas_PointerMoved;
                }
            }
    
            private void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
            {
                if (MovingObject != null)
                {
                    Canvas canvas = sender as Canvas;
    
                    Point canvasPoint = e.GetCurrentPoint(canvas).Position;
                    Point objPosition = e.GetCurrentPoint((MovingObject as FrameworkElement)).Position;
                    if (e.GetCurrentPoint(MovingObject as Control).Properties.IsLeftButtonPressed) //e.Pointer.IsInContact ==true)
                    {
    //This condition will take care that control should not go outside the canvas
                        if ((e.GetCurrentPoint((MovingObject as FrameworkElement).Parent as FrameworkElement).Position.X - FirstXPos > 0) && (e.GetCurrentPoint((MovingObject as FrameworkElement).Parent as FrameworkElement).Position.X - FirstXPos < canvas.ActualWidth - (MovingObject as FrameworkElement).ActualWidth))
                        {
                            (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty, e.GetCurrentPoint((MovingObject as FrameworkElement).Parent as FrameworkElement).Position.X - FirstXPos);
                        }
    
    //This condition will take care that control should not go outside the canvas
                        if ((e.GetCurrentPoint((MovingObject as FrameworkElement).Parent as FrameworkElement).Position.Y - FirstYPos > 0) && (e.GetCurrentPoint((MovingObject as FrameworkElement).Parent as FrameworkElement).Position.Y - FirstYPos < canvas.ActualHeight - (MovingObject as FrameworkElement).ActualHeight))
                        {
                            (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty, e.GetCurrentPoint((MovingObject as FrameworkElement).Parent as FrameworkElement).Position.Y - FirstYPos);
                        }
                    }
                }
            }
    
            private void Ellipse_PointerReleased(object sender, PointerRoutedEventArgs e)
            {
                MovingObject = null;
            }
    }
