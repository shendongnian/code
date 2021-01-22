    Imports System.Drawing
    Imports System.Drawing.Imaging
    
    Public Shared Function GetBMPTransparent(bmp As Bitmap, TranspFactor As Integer) As Bitmap
    
            Dim transpBmp As Bitmap = New Bitmap(bmp.Width, bmp.Height)
            Using attr As ImageAttributes = New ImageAttributes()
                Dim matrix As ColorMatrix = New ColorMatrix() With {.Matrix33 = CSng(TranspFactor / 255)}
                attr.SetColorMatrix(matrix)
                Using g As Graphics = Graphics.FromImage(transpBmp)
                    g.DrawImage(bmp, _
                        New Rectangle(0, 0, bmp.Width, bmp.Height), _
                        0, 0, bmp.Width, bmp.Height, _
                        GraphicsUnit.Pixel, attr)
                End Using
            End Using
            Return transpBmp
    
        End Function
     
