    Module Module1
    
        Sub Main()
            Dim Rgx As New System.Text.RegularExpressions.Regex("Pattern", _
                System.Text.RegularExpressions.RegexOptions.IgnoreCase _
                Or System.Text.RegularExpressions.RegexOptions.Singleline _
                Or System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace)
    
    
            For Each result As System.Text.RegularExpressions.Match In Rgx.Matches("Find pattern here.")
                'Do Something
            Next
        End Sub
    
    End Module
