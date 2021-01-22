    <Extension()>
    Public Function IsNullOrWhiteSpace(value As String) As Boolean
        If value Is Nothing Then
            Return True
        End If
        For i As Integer = 0 To value.Length - 1
            If Not Char.IsWhiteSpace(value(i)) Then
                Return False
            End If
        Next
        Return True
    End Function
    <Extension()>
    Public Function UnPascalCase(text As String) As String
        If text.IsNullOrWhiteSpace Then
            Return String.Empty
        End If
        Dim newText = New StringBuilder()
        newText.Append(text(0))
        For i As Integer = 1 To text.Length - 1
            Dim currentUpper = Char.IsUpper(text(i))
            Dim prevUpper = Char.IsUpper(text(i - 1))
            Dim nextUpper = If(text.Length > i + 1, Char.IsUpper(text(i + 1)) Or Char.IsWhiteSpace(text(i + 1)), prevUpper)
            Dim spaceExists = Char.IsWhiteSpace(text(i - 1))
            If (currentUpper And Not spaceExists And (Not nextUpper Or Not prevUpper)) Then
                newText.Append(" ")
            End If
            newText.Append(text(i))
        Next
        Return newText.ToString()
    End Function
