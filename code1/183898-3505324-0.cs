    Public Shared Function GetTimeSpanString(ByVal ts As TimeSpan) As String
            Dim output As New StringBuilder()
    
            Dim needsComma As Boolean = False
    
            If ts = Nothing Then
    
                Return "00:00:00"
    
            End If
    
            If ts.TotalHours >= 1 Then
                output.AppendFormat("{0} hr", Math.Truncate(ts.TotalHours))
                If ts.TotalHours > 1 Then
                    output.Append("s")
                End If
                needsComma = True
            End If
    
            If ts.Minutes > 0 Then
                If needsComma Then
                    output.Append(", ")
                End If
                output.AppendFormat("{0} m", ts.Minutes)
                'If ts.Minutes > 1 Then
                '    output.Append("s")
                'End If
                needsComma = True
            End If
    
            Return output.ToString()
    		
     End Function		
     
