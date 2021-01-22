    SPList MyLib = TheWeb.Lists["MyLibrary"];
    if (MyLib != null)
    {
        if (MyLib.Items.Count > 0)
        {
            foreach(SPListItem AnItem in MyLib.Items)
            {
                  SPFile TheFile = AnItem.File;
                  if (TheFile.CheckOutType != SPFile.SPCheckOutType.None)
                  {
                       TheFile.CheckIn("Check in comment", SPCheckinType.MajorCheckIn);
                       TheFile.Approve("Approval comment");
                  }
            }
        }
    }
