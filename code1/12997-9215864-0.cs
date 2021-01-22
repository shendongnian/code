    Private Function IsValidImage(imageStream As System.IO.Stream) As Boolean
    
                If (imageStream.Length = 0) Then
                    isvalidimage = False
                    Exit Function
                End If
    
                Dim pngByte() As Byte = New Byte() {137, 80, 78, 71}
                Dim pngHeader As String = System.Text.Encoding.ASCII.GetString(pngByte)
    
                Dim jpgByte() As Byte = New Byte() {255, 216}
                Dim jpgHeader As String = System.Text.Encoding.ASCII.GetString(jpgByte)
    
                Dim bmpHeader As String = "BM"
                Dim gifHeader As String = "GIF"
    
                Dim header(3) As Byte
    
                Dim imageHeaders As String() = New String() {jpgHeader, bmpHeader, gifHeader, pngHeader}
                imageStream.Read(header, 0, header.Length)
    
                Dim isImageHeader As Boolean = imageHeaders.Count(Function(str) System.Text.Encoding.ASCII.GetString(header).StartsWith(str)) > 0
    
                If (isImageHeader) Then
                    Try
                        System.Drawing.Image.FromStream(imageStream).Dispose()
                        imageStream.Close()
                        IsValidImage = True
                        Exit Function
                    Catch ex As Exception
                        System.Diagnostics.Debug.WriteLine("Not an image")
                    End Try
                Else
                    System.Diagnostics.Debug.WriteLine("Not an image")
                End If
    
                imageStream.Close()
                IsValidImage = False
            End Function
