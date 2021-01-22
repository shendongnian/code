    DateTime tempDateTime = GetDateTimeFromSomeService();
    DateTime dateTime = tempDateTime.ToUniversalTime();
    SYSTEMTIME st = new SYSTEMTIME();
    // All of these must be short
    st.wYear = (short)dateTime.Year;
    st.wMonth = (short)dateTime.Month;
    st.wDay = (short)dateTime.Day;
    st.wHour = (short)dateTime.Hour;
    st.wMinute = (short)dateTime.Minute;
    st.wSecond = (short)dateTime.Second;
    // invoke the SetSystemTime method now
    SetSystemTime(ref st); 
