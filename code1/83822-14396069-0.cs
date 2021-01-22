    Public Class ByteArrayToIconConverter
    Implements IValueConverter
    ' Define the Convert method to change a byte[] to icon.
    Public Function Convert(ByVal value As Object, _
        ByVal targetType As Type, ByVal parameter As Object, _
        ByVal culture As System.Globalization.CultureInfo) As Object _
        Implements System.Windows.Data.IValueConverter.Convert
        If Not value Is Nothing Then
            ' value is the data from the source object.
            Dim data() As Byte = CType(value, Byte())
            Dim ms1 As MemoryStream = New MemoryStream(data)
            Dim ms2 As MemoryStream = New MemoryStream()
            Dim img As New BitmapImage()
            img.BeginInit()
            img.StreamSource = ms1
            img.EndInit()
            Dim encoder As New PngBitmapEncoder()  
            encoder.Frames.Add(BitmapFrame.Create(img))
            encoder.Save(ms2)
            Dim bmp As New Bitmap(ms2)
            Dim newIcon As Icon = Icon.FromHandle(bmp.GetHicon())
            Return newIcon
        End If
    End Function
    ' ConvertBack is not implemented for a OneWay binding.
    Public Function ConvertBack(ByVal value As Object, _
        ByVal targetType As Type, ByVal parameter As Object, _
        ByVal culture As System.Globalization.CultureInfo) As Object _
        Implements System.Windows.Data.IValueConverter.ConvertBack
        Throw New NotImplementedException
    End Function
    End Class
