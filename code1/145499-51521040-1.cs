    Public Module Extensions
        <Extension()>
        Public Sub AppendFormatWithNewLine(ByRef sb As System.Text.StringBuilder, ByVal format As String, ParamArray values() As Object)
            sb.AppendLine(String.Format(format, values))
        End Sub
    End Module
