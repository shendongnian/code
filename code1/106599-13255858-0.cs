    Public Class clsBSHelpers
    
        Public Structure Key
    
            Public PropertyName As String
            Public Value As Object
    
            Sub New(ByVal pPropertyName As String, ByVal pValue As Object)
                PropertyName = pPropertyName
                Value = pValue
            End Sub
    
        End Structure
    
        Public Shared Function Find(ByVal Source As BindingSource, ByVal ParamArray keys As Key()) As Boolean
    
            Dim sb As New Text.StringBuilder
            For i As Integer = 0 To keys.Length - 1
                If sb.Length > 0 Then
                    sb.Append(",")
                End If
                sb.Append(keys(i).PropertyName)
            Next
    
            Source.Sort = sb.ToString
            Dim underlyingView As DataView = DirectCast(Source.List, DataView)
            Dim searchVals As New List(Of Object)
            For i As Integer = 0 To keys.Length - 1
                searchVals.Add(keys(i).Value)
            Next
    
            Dim ListIndex As Integer = underlyingView.Find(searchVals.ToArray)
    
            If ListIndex >= 0 Then
                Source.Position = ListIndex
                Find = True
            Else
                Find = False
                'No matches, so what you need to do...
            End If
    
            Return Find
    
        End Function
    
    End Class
