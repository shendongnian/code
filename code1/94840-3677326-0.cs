    Dim _previous As Point = Nothing
    Dim _pen As Pen = New Pen(Color.Black)
    Dim drawing As Boolean = False
    ''' <summary>
    ''' This handles the signature drawing events (drawing)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub signature_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles signature.MouseMove
        If drawing = True Then
            If signature.Image Is Nothing Then
                Dim bmp As Bitmap = New Bitmap(signature.Width, signature.Height)
                Using g As Graphics = Graphics.FromImage(bmp)
                    g.Clear(Color.White)
                End Using
                signature.Image = bmp
            End If
            Using g As Graphics = Graphics.FromImage(signature.Image)
                g.DrawLine(_pen, _previous.X, _previous.Y, e.X, e.Y)
            End Using
            signature.Invalidate()
            _previous = New Point(e.X, e.Y)
        End If
    End Sub
    ''' <summary>
    ''' this indicates somebody is going to write a signature
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub signature_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles signature.MouseDown
        _previous = New Point(e.X, e.Y)
        drawing = True
        signature_MouseMove(sender, e)
    End Sub
    ''' <summary>
    ''' the signature is done.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub signature_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles signature.MouseUp
        _previous = Nothing
        drawing = False
    End Sub
