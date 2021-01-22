    public partial class DragUserControl : UserControl
    {
        public DragUserControl()
        {
            InitializeComponent();
        }
        object MovingObject;
        double FirstXPos, FirstYPos;
        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.MovingObject = this;
            FirstXPos = e.GetPosition(MovingObject as Control).X;
            FirstYPos = e.GetPosition(MovingObject as Control).Y;
            Canvas canvas = this.Parent as Canvas;
            if (canvas != null)
            {
                canvas.PreviewMouseMove += this.MouseMove;
            }
        }
        private void MouseMove(object sender, MouseEventArgs e)
        {
            /*
             * In this event, at first we check the mouse left button state. If it is pressed and 
             * event sender object is similar with our moving object, we can move our control with
             * some effects.
             */
            Canvas canvas = sender as Canvas;
            Point canvasPoint = e.GetPosition(canvas);
            Point objPosition = e.GetPosition((MovingObject as FrameworkElement));
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (MovingObject != null)
                {
    //This condition will take care that control should not go outside the canvas.
                        if ((e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - FirstXPos > 0) && (e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - FirstXPos < canvas.ActualWidth - (MovingObject as FrameworkElement).ActualWidth))
                        {
                            (MovingObject as FrameworkElement).SetValue(Canvas.LeftProperty, e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).X - FirstXPos);
                        }
    
    //This condition will take care that control should not go outside the canvas.
                        if ((e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - FirstYPos > 0) && (e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - FirstYPos < canvas.ActualHeight - (MovingObject as FrameworkElement).ActualHeight))
                        {
                            (MovingObject as FrameworkElement).SetValue(Canvas.TopProperty, e.GetPosition((MovingObject as FrameworkElement).Parent as FrameworkElement).Y - FirstYPos);
                        }
                    }
                }
            }
            
            private void Ellipse_PreviewMouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
            {
                MovingObject = null;
            }
        }
