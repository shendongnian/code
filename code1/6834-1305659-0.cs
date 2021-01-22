    Private Function IsGuidWithOptionalBraces(ByRef strValue As String) As Boolean
        If String.IsNullOrEmpty(strValue) Then
            Return False
        End If
        Return System.Text.RegularExpressions.Regex.IsMatch(strValue, "^[\{]?[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}[\}]?$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
    Private Function IsGuidWithoutBraces(ByRef strValue As String) As Boolean
        If String.IsNullOrEmpty(strValue) Then
            Return False
        End If
        Return System.Text.RegularExpressions.Regex.IsMatch(strValue, "^[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
    Private Function IsGuidWithBraces(ByRef strValue As String) As Boolean
        If String.IsNullOrEmpty(strValue) Then
            Return False
        End If
        Return System.Text.RegularExpressions.Regex.IsMatch(strValue, "^\{[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}\}$", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
    End Function
