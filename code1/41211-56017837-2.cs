    public struct SystemTime
                {
                    public ushort Year;
                    public ushort Month;
                    public ushort Day;
                    public ushort Hour;
                    public ushort Minute;
                    public ushort Second;
                    public ushort Millisecond;
                    
                };
    SystemTime st = new SystemTime();
        st.Year = 2019;
        st.Month = 10;
        st.Day = 15;
        st.Hour = 10;
        st.Minute = 20;
        st.Second = 30;
            
        SetSystemTime(ref st);
