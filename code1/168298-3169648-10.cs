    [ContentProperty("Window")]
    public class WindowExpander : Expander
    {
      Storyboard _storyboard;
      public static WindowExpander()
      {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(WindowExpander), new FrameworkPropertyMetadata(typeof(WindowExpander)));
        IsExpandedProperty.OverrideMetadata(typeof(WindowExpander), new FrameworkPropertyMetadata
        {
          PropertyChangedCallback = (obj, e) =>
            {
              var expander = (WindowExpander)obj;
              if(expander.Window!=null)
              {
                expander.SwapContent(expander.Window);
                expander.AnimateWindow();
              }
            }
        });
      }
      public Window Window { get { return (Window)GetValue(WindowProperty); } set { SetValue(WindowProperty, value); } }
      public static readonly DependencyProperty WindowProperty = DependencyProperty.Register("Window", typeof(Window), typeof(WindowExpander), new UIPropertyMetadata
      {
        PropertyChangedCallback = (obj, e) =>
        {
          var expander = (WindowExpander)obj;
          var oldWindow = (Window)e.OldValue;
          var newWindow = (Window)e.NewValue;
          if(oldWindow!=null)
          {
            if(!expander.IsExpanded) expander.SwapContent(oldWindow);
            oldWindow.StateChanged -= expander.OnStateChanged;
          }
          expander.ConstructLiveThumbnail();
          if(newWindow!=null)
          {
            if(!expander.IsExpanded) expander.SwapContent(newWindow);
            newWindow.StateChanged -= expander.OnStateChanged;
          }
        }
      });
      private void ConstructLiveThumbnail()
      {
        if(Window==null)
          Header = null;
        else
        {
          var rectangle = new Rectangle { Fill = new VisualBrush { Visual = (Visual)Window.Content } };
          rectangle.SetBinding(Rectangle.WidthProperty, new Binding("Width") { Source = Window });
          rectangle.SetBinding(Rectangle.HeightProperty, new Binding("Height") { Source = Window });
          Header = rectangle;
        }
      }
      private void SwapContent(Window window)
      {
        var a = Header; var b = window.Content;
        Header = null;  window.Content = null;
        Header = b;     window.Content = a;
      }
      private void AnimateWindow()
      {
        if(_storyboard!=null)
          _storyboard.Stop(Window);
        var myUpperLeft = PointToScreen(new Point(0, 0));
        var myLowerRight = PointToScreen(new Point(ActualWidth, ActualHeight));
        var myRect = new Rect(myUpperLeft, myLowerRight);
        var winRect = new Rect(Window.Left, Window.Top, Window.Width, Window.Height);
        var fromRect = IsExpanded ? myRect : winRect;  // Rect where the window will animate from
        var toRect = IsExpanded ? winRect : myRect;    // Rect where the window will animate to
        _storyboard = new Storyboard { FillBehavior = FillBehavior.Stop };
        // ... code to build storyboard here ...
        // ... should animate "Top", "Left", "Width" and "Height" of window from 'fromRect' to 'toRect' using desired timeframe
        // ... should also animate Visibility=Visibility.Visible at time=0
        _storyboard.Begin(Window);
        Window.Visibility = IsExpanded ? Visibility.Visible : Visibility.Hidden;
      }
      private void OnStateChanged(object sender, EventArgs e)
      {
        if(IsExpanded && Window.WindowState == WindowState.Minimized)
        {
          Window.WindowState = WindowState.Normal;
          IsExpanded = false;
        }
      }
    }
