      singleLoadControl.Visible = false;
      singleTruckControl.Visible = false;
      multiTruckControl.Visible = false;
      multiLoadControl.Visible = false;
      singleLoadControl.Visible = (PostingType == PostingTypes.Loads && !IsMultiPost);
      singleTruckControl.Visible = (PostingType == PostingTypes.Trucks && !IsMultiPost);
      multiLoadControl.Visible = (PostingType == PostingTypes.Loads && IsMultiPost);
      multiTruckControl.Visible = (PostingType == PostingTypes.Trucks && IsMultiPost);
