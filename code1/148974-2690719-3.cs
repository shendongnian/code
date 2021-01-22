     public event EventHandler MovedPrevious;
     public event EventHandler MovedNext;
    
         protected void OnMovedPrevious(object sender, RoutedEventArgs e)
         {
           if (MovedPrevious != null)
           {
              MovedPrevious(this, e);   
           }
         }
        
         protected void OnMovedNext(object sender, RoutedEventArgs e)
         {
            if (MovedNext != null)
            {
               MovedNext(this, e);   
            }
         }
