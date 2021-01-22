    Public Shared Function FormatTimeSpan(span As TimeSpan) As String
        Return String.Format("{0}hr {1}mn {2}sec", _
                             CInt(Math.Truncate(span.TotalHours)), _
                             span.Minutes, _
                             span.Seconds)
    End Function
