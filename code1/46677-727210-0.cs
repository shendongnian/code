    Public Class WeekDayComparer
      Implements IComparer(Of DateTime)
    
      Public Function Compare(ByVal x As Date, ByVal y As Date) As Integer Implements System.Collections.Generic.IComparer(Of Date).Compare
    
        Return x.DayOfWeek.CompareTo(y.DayOfWeek)
    
      End Function
    
    End Class
