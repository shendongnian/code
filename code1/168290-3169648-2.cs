    public class WindowExpander : Expander
    {
      Storyboard _storyboard;
      public static WindowExpander()
      {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowExpander), new PropertyMetadata(typeof(WindowExpander)));
        ContentProperty.OverrideMetadata(typeof(WindowExpander), new FrameworkPropertyMetadata
        {
          PropertyChangedCallback = (obj, e) =>
            {
              var expander = (WindowExpander)obj;
              var oldWindow = (Window)e.OldValue;
              var newWindow = (Window)e.NewValue;
              if(oldWindow!=null)
              {
                if(!expander.IsExpanded) expander.SwapContent(oldWindow);
                oldWindow.StateChanged -= OnStateChanged;
              }
              expander.ConstructLiveThumbnail();
              if(newWindow!=null)
              {
                if(!expander.IsExpanded) expander.SwapContent(newWindow);
                newWindow.StateChanged -= OnStateChanged;
              }
            }
        });
        IsExpandedProperty.OverrideMetadata(typeof(WindowExpander), new FrameworkPropertyMetadata
        {
          PropertyChangedCallback = (obj, e) =>
            {
              var expander = (WindowExpander)obj;
              var window = (Window)expander.Content;
              if(window!=null)
              {
                expander.SwapContent(window);
                expander.AnimateWindow(window);
              }
            }
        });
      }
      private void ConstructLiveThumbnail()
      {
        var window = (Window)Content;
        if(window==null)
          Header = null;
        else
        {
          var rectangle = new Rectangle { Fill = new VisualBrush { Visual = (Visual)window.Content } };
          rectangle.SetBinding(Rectangle.WidthProperty, new Binding("Width") { Source = window });
          rectangle.SetBinding(Rectangle.HeightProperty, new Binding("Height") { Source = window });
          Header = rectangle;
        }
      }
      private void SwapContent(Window window)
      {
        var a = Header; var b = window.Content;
        Header = null;  window.Content = null;
        Header = b;     window.Content = a;
      }
      private void AnimateWindow(Window window)
      {
        if(_storyboard!=null)
          _storyboard.Stop(window);
        var myUpperLeft = PointToScreen(new Point(0,0));
        var myLowerRight = PointToScreen(new Point(ActualWidth, ActualHeight));
        var myRect = new Rect(myUpperLeft, myLowerRight);
        var winRect = new Rect(window.Left, window.Top, window.Width, window.Height);
        var fromRect = IsExpanded ? myRect : winRect;  // Rect where the window will animate from
        var toRect = IsExpanded ? winRect : myRect;    // Rect where the window will animate to
        _storyboard = new Storyboard { FillBehavior = FillBehavior.Stop };
        // ... code to build storyboard here ...
        // ... should animate "Top", "Left", "Width" and "Height" of window from 'fromRect' to 'toRect' using desired timeframe
        // ... should also animate Visibility=Visibility.Visible at time=0
        _storyboard.Begin(window);
        window.Visibility = IsExpanded ? Visibility.Visible : Visibility.Hidden;
      }
      private static void OnStateChanged(object sender, EventArgs e)
      {
        var window = (Window)sender;
        if(IsExpanded && window.WindowState == WindowState.Minimized)
        {
          window.WindowState = WindowState.Normal;
          IsExpanded = false;
        }
      }
    }
