      Public Enum Formats
        Unknown
        Bmp
        Emf
        Wmf
        Gif
        Jpeg
        Png
        Tiff
        Icon
      End Enum
    
      Public Shared Function ImageFormat(ByVal Image As System.Drawing.Image) As Formats
        If Not System.Enum.TryParse(Of Formats)(System.Drawing.Imaging.ImageCodecInfo.GetImageDecoders().ToList().[Single](Function(ImageCodecInfo) ImageCodecInfo.FormatID = Image.RawFormat.Guid).FormatDescription, True, ImageFormat) Then
          Return Formats.Unknown
        End If
      End Function
