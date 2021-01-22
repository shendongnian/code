    bool selected;
    
    MouseEnter(..,..)
    {
     if (!selected)
       selected = true;
     else
       selected = false;
    
      if (selected)
       /.. Logic Here ../
    }
    
    MouseLeave()
    {
      if (selected)
       return;
      
    /.. Logic Here ../
    }
    
    
