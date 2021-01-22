    Private Sub rtb_ContentsResized(ByVal sender As Object, ByVal e As System.Windows.Forms.ContentsResizedEventArgs) Handles txtQuestion.ContentsResized
            Dim h = e.NewRectangle.Height, w = e.NewRectangle.Width
            h = Math.Max(h, sender.Font.Height)
            h = Math.Min(h, Me.ClientSize.Height - 10 - sender.Top)
            h += sender.Height - sender.ClientSize.Height + 1
            sender.Height = h
    End Sub
