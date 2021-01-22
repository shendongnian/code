    public bool IsOnScreen( Form form )
    {
       Screen[] screens = Screen.AllScreens;
       foreach( Screen screen in screens )
       {
          Point formTopLeft = new Point( form.Left, form.Top );
    
          if( screen.WorkingArea.Contains( formTopLeft ) )
          {
             return true;
          }
       }
    
       return false;
    }
