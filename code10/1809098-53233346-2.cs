    Public Class TextInListTrueFalseConverter
        Implements IMultiValueConverter
    
        Public Function Convert(values() As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IMultiValueConverter.Convert
            Dim Checked As Boolean = False
            If Not values Is Nothing Then
                If values.Count = 2 Then
                    Dim ListString As String = values(0)
                    Dim WordToFind As String = values(1)
                    If Not ListString Is Nothing Then
                        Dim KeywordList As List(Of String) = ListString.Split(";").ToList 'Assuming you seperator is a ;
                        If KeywordList.Contains(WordToFind) Then Checked = True
                    End If
                End If
            End If
            Return Checked
        End Function
    
        Public Function ConvertBack(value As Object, targetTypes() As Type, parameter As Object, culture As CultureInfo) As Object() Implements IMultiValueConverter.ConvertBack
            Throw New NotImplementedException()
        End Function
    End Class
