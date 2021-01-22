     protected virtual void OnMovedPrevious(EventArgs e)
     {
       var handler = MovedPrevious;
       if (handler != null)
         handler(this, e);   
     }
     protected virtual void OnMovedNext(EventArgs e)
     {
       var handler = MovedNext;
       if (handler != null)
         handler(this, e);   
     }
