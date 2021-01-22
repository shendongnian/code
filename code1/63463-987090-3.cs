    public bool IsOnScreen( Form form )
    {
       Screen[] screens = Screen.AllScreens;
       foreach( Screen screen in screens )
       {
          Rectangle formRectangle = new Rectangle( form.Left, form.Top, 
                                                   form.Width, form.Height );
          if( screen.WorkingArea.Contains( formRectangle ) )
          {
             return true;
          }
       }
       return false;
    }
