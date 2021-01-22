    if (IsChanged)
    {
          return;
    }
    
    if (CurrentStatus == Status.None) 
    {
         CancelClose();
         return;
    }
    
    if (CurrentStatus == Status.Saving) 
    {
      //     IsChanged = false;
    }
