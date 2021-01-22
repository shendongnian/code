    Dim AllResults As MatchCollection
    Try
    	Dim RegexObj As New Regex("\w+", RegexOptions.Multiline)
    	AllResults = RegexObj.Matches("Here is ""my string""    it has ""six  matches"")
    	If AllResults.Count > 0 Then
    		' Access individual matches using AllResults.Item[]
    	Else
    		' Match attempt failed
    	End If
    Catch ex As ArgumentException
    	'Syntax error in the regular expression
    End Try
