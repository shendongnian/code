    SYSTEMTIME st = new SYSTEMTIME();
    GetSystemTime(ref st);
    // Adds one hour to the time that was retrieved from GetSystemTime
    st.wHour = (ushort)(st.wHour + 1 % 24);
    var result = SetSystemTime(ref st);
    if (result == 0)
    {
         // Something went wrong
    }
    else
    {
        // The time will now be 1hr later than it was previously
    }
            
