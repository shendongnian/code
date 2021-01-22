    //C#.NET
        public static bool IsDaylightSavingTime()
        {
            return IsDaylightSavingTime(DateTime.Now);
        }
        public static bool IsDaylightSavingTime(DateTime timeToCheck)
        {
            bool isDST = false;
            System.Globalization.DaylightTime changes 
                = TimeZone.CurrentTimeZone.GetDaylightChanges(timeToCheck.Year);
            if (timeToCheck >= changes.Start && timeToCheck <= changes.End)
            {
                isDST = true;
            }
            return isDST;
        }
    '' VB.NET
    Const noDate As Date = #1/1/1950#
    Public Shared Function IsDaylightSavingTime( _ 
     Optional ByVal timeToCheck As Date = noDate) As Boolean
        Dim isDST As Boolean = False
        If timeToCheck = noDate Then timeToCheck = Date.Now
        Dim changes As DaylightTime = TimeZone.CurrentTimeZone _
             .GetDaylightChanges(timeToCheck.Year)
        If timeToCheck >= changes.Start And timeToCheck <= changes.End Then
            isDST = True
        End If
        Return isDST
    End Function
