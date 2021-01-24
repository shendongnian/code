    public class YourClass
    {
      private TimeSpan[] Word = new TimeSpan[300];
      private Timer[] Timer = new Timer[300];
      private GazeElement[] gazeButtonControl = new GazeElement[300];
      public YourMethod(...)
      {
        for (int i = 0; i < 300; i++)
        {
          // first find gaze block where parentControl is the control containing your gaze blocks.
          var gazeBlock = (UIElement)parentControl.FindChildByName("GazeBlock" + (i + 1));
          
          gazeButtonControl[i] = GazeInput.GetGazeElement(gazeBlock);
          if (gazeButtonControl[i] == null)
          {
            gazeButtonControl[i] = new GazeElement();
            GazeInput.SetGazeElement(gazeBlock, gazeButtonControl[i]);
          }
          Word[i] = TimeSpan.Zero;
          Timer[i] = new Stopwatch();
          gazeButtonControl[i].StateChanged += GazeBlockControl_StateChanged;
        }
      }
      private void GazeBlockControl_StateChanged(object sender, StateChangedEventArgs ea)
      {
        // get the GazeElement for which this event was raised
        var changedControl = (GazeElement)sender;
        // find its index in your list of GazeElements.
        var i = Array.IndexOf(gazeButtonControl, changedControl); 
        if (ea.PointerState == PointerState.Enter)
        {
          Timer[i].Start();
        }
        if (ea.PointerState == PointerState.Exit)
        {
          Timer[i].Stop();
          Word[i] += Timer.Elapsed;
          File.WriteAllText(@"*insert path here", Word[i].ToString());
          Timer[i].Reset();
        }
      }
    }
