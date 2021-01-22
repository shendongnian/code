      Public Function Match(Input As String) As Match
        If Regex Is Nothing Then Return Nothing
        Dim RegexMatch As System.Text.RegularExpressions.Match = Nothing
        Dim Func As New Func(Of String, System.Text.RegularExpressions.Match)(Function(x As String) Regex.Match(x))
        If Runtime.TryExecute(Of String, System.Text.RegularExpressions.Match)(Func, Input, 2000, RegexMatch) Then
          Return (New Match(Me, Regex.Match(Input), Input))
        Else
          Return Nothing
        End If
      End Function
