    private bool isDown;
    
    MouseDown()
    {
       isDown = true;
    }
    
    MouseUp()
    {
       isDown = false;
    }
    OnMouseMove()
    {
       if(isDown)
       {
           //Do something...
       }
    }
