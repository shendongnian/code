        ''' <summary>
    ''' Converts an image to Black and White
    ''' </summary>
    ''' <param name="image">Image to convert</param>
    ''' <param name="Mode">Convertion mode</param>
    ''' <param name="tolerance">Tolerancia del colores</param>
    ''' <returns>Converts an image to Black an white</returns>
    ''' <remarks></remarks>
    Public Function PureBW(ByVal image As System.Drawing.Bitmap, Optional ByVal Mode As BWMode = BWMode.By_Lightness, Optional ByVal tolerance As Single = 0) As System.Drawing.Bitmap
        Dim x As Integer
        Dim y As Integer
        If tolerance > 1 Or tolerance < -1 Then
            Throw New ArgumentOutOfRangeException
            Exit Function
        End If
        For x = 0 To image.Width - 1 Step 1
            For y = 0 To image.Height - 1 Step 1
                Dim clr As Color = image.GetPixel(x, y)
                If Mode = BWMode.By_RGB_Value Then
                    If (CInt(clr.R) + CInt(clr.G) + CInt(clr.B)) > 383 - (tolerance * 383) Then
                        image.SetPixel(x, y, Color.White)
                    Else
                        image.SetPixel(x, y, Color.Black)
                    End If
                Else
                    If clr.GetBrightness > 0.5 - (tolerance / 2) Then
                        image.SetPixel(x, y, Color.White)
                    Else
                        image.SetPixel(x, y, Color.Black)
                    End If
                End If
            Next
        Next
        Return image
    End Function
 
