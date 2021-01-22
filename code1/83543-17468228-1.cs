    DateTime FirstYearRegistered = Convert.ToDateTime(Collection["FirstYearRegistered"]);
    if (FirstYearRegistered != DateTime.MinValue)
    {
        vehicleData.DateFirstReg = FirstYearRegistered;
    }  
