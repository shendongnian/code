    private bool IsPasswordSet 
    { 
         get
         {
           return !String.IsNullOrEmpty(_password);
         }
    }
