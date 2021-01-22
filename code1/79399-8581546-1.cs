    private enum TaskBarLocation { TOP, BOTTOM, LEFT, RIGHT } 
    
    private TaskBarLocation GetTaskBarLocation()
    {
      //System.Windows.SystemParameters....
      if (SystemParameters.WorkArea.Left > 0) 
        return TaskBarLocation.LEFT;
      if (SystemParameters.WorkArea.Top > 0)
        return TaskBarLocation.TOP;
      if (SystemParameters.WorkArea.Left == 0 
        && SystemParameters.WorkArea.Width < SystemParameters.PrimaryScreenWidth) 
          return TaskBarLocation.RIGHT;
      return TaskBarLocation.BOTTOM;
    }
