     Public Function RemoverTildes(stIn As String) As String
        Dim stFormD As String = stIn.Normalize(NormalizationForm.FormD)
        Dim sb As New StringBuilder()
        For ich As Integer = 0 To stFormD.Length - 1
            Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
            If uc <> UnicodeCategory.NonSpacingMark Then
                sb.Append(stFormD(ich))
            End If
        Next
        Return (sb.ToString().Normalize(NormalizationForm.FormC))
    End Function
