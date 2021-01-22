    Imports System.Collections.ObjectModel
    
    Namespace Converters
    
        <ValueConversion(GetType(ReadOnlyObservableCollection(Of ValidationError)), GetType(String))> _
        Public Class ErrorContentConverter
            Implements IValueConverter
    
            Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
                Dim errors As ReadOnlyObservableCollection(Of ValidationError) = TryCast(value, ReadOnlyObservableCollection(Of ValidationError))
                If errors IsNot Nothing Then
                    If errors.Count > 0 Then
                        Return errors(0).ErrorContent
                    End If
                End If
                Return String.Empty
            End Function
    
            Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
                Throw New NotImplementedException()
            End Function
    
        End Class
    
    End Namespace
