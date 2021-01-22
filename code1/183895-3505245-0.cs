    Public Shared Function FormatTimeSpan(span As TimeSpan) As String
        Return String.Format("{0}hr {1}mn {2}sec", _
                             CType(span.TotalHours, Integer), _
                             span.Minutes, _
                             span.Seconds)
    End Function
