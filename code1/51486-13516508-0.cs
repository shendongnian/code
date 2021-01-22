    Point cursorPoint;
    int minutesIdle=0;
    private bool isIdle(int minutes)
    {
        return minutesIdle >= minutes;
    }
        
    private void idleTimer_Tick(object sender, EventArgs e)
    {
        if (Cursor.Position != cursorPoint)
        {
            // The mouse moved since last check
            minutesIdle = 0;
        }
        else
        {
            // Mouse still stoped
            minutesIdle++;
        }
        // Save current position
        cursorPoint = Cursor.Position;
    }
   
