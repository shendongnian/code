    switch (PostingType)
    {
    case PostingTypes.Loads:
       singleLoadControl.Visible = !IsMultiPost;
       multiTruckControl.Visible = IsMultiPost;
       singleTruckControl.Visible = false;
       multiTruckLoadControl.Visible = false;
       break;
    
    case PostingTypes.Trucks:
       singleLoadControl.Visible = false;
       multiTruckControl.Visible = false;
       singleTruckControl.Visible = !IsMultiPost;
       multiLoadControl.Visible = IsMultiPost;
       break;
    
    default:
       throw InvalidOperationException("Unknown enumeration value.");
    }
