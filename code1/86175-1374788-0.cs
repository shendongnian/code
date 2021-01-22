         singleLoadControl.Visible = false;
         singleTruckControl.Visible = false;
         multiTruckControl.Visible = false;
         multiLoadControl.Visible = false;
    
        if (PostingType == PostingTypes.Loads && !IsMultiPost)
        {
                singleLoadControl.Visible = true;
        }
        else if (PostingType == PostingTypes.Trucks && !IsMultiPost)
        {
              singleTruckControl.Visible = true;
        }
        else if (PostingType == PostingTypes.Loads && IsMultiPost)
        {
            multiLoadControl.Visible = true;
        }
        else if (PostingType == PostingTypes.Trucks && IsMultiPost)
        {
              multiTruckControl.Visible = true;
    }
