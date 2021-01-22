    Public Class WeekDayComparer
      Implements IComparer(Of MyEvent)
    
      Public Function Compare(ByVal x As MyEvent, ByVal y As MyEvent) As Integer Implements System.Collections.Generic.IComparer(Of MyEvent).Compare
        Return GetDayOfWeekNumber(x.DayOfWeek).CompareTo(GetDayOfWeekNumber(y.DayOfWeek))
    
      End Function
      Private Function GetDayOfWeekNumber(ByVal dayOfWeek As String) As Integer
         Select Case dayOfWeek.ToLower()
           Case "monday"
             Return 0
           Case "tuesday"
             Return 1
           Case "wednesday"
             Return 2
           Case "thursday"
             Return 3
           Case "friday"
             Return 4
           Case "saturday"
             Return 5
           Case "sunday"
             Return 6
           Case Else
             Return 7
         End Select
      End Function
    
    End Class
