    private void ControlSelect()
    {
        if (PostingType == PostingTypes.Loads && !IsMultiPost)
        {
            singleLoadControl.Visible = true;
            singleTruckControl.Visible = false;
            multiTruckControl.Visible = false;
            multiLoadControl.Visible = false;
            return;
        }
        if (PostingType == PostingTypes.Trucks && !IsMultiPost)
        {
            singleLoadControl.Visible = false;
            singleTruckControl.Visible = true;
            multiTruckControl.Visible = false;
            multiLoadControl.Visible = false;
            return;
        }
        if (PostingType == PostingTypes.Loads && IsMultiPost)
        {
            singleLoadControl.Visible = false;
            singleTruckControl.Visible = false;
            multiTruckControl.Visible = false;
            multiLoadControl.Visible = true;
            return;
        }
        if (PostingType == PostingTypes.Trucks && IsMultiPost)
        {
            singleLoadControl.Visible = false;
            singleTruckControl.Visible = false;
            multiTruckControl.Visible = true;
            multiLoadControl.Visible = false;
            return;
        }
    }
