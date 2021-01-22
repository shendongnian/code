    singleLoadControl.Visible  = 
          PostingType == PostingTypes.Loads  && !IsMultiPost;      
    singleTruckControl.Visible = 
          PostingType == PostingTypes.Trucks && !IsMultiPost;      
    multiTruckControl.Visible  = 
          PostingType == PostingTypes.Loads  && IsMultiPost;      
    multiLoadControl.Visible   =  
          PostingType == PostingTypes.Trucks && IsMultiPost;
