    Public Class Product
        Public Property Id As Integer
        Public Property Name As String
        <TypeConverter(GetType(CategoryConverter))>
        Public Property Category As Category
    End Class
    Public Class Category
        Public Property Id As Integer
        Public Property Name As String
        Public Overrides Function ToString() As String
            Return $"{Id} - {Name}"
        End Function
    End Class
