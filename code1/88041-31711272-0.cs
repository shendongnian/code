        Private Sub TextBoxSizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Dim textBoxRect As Size = TextRenderer.MeasureText(TextBox.Text, TextBox.Font, New Size(TextBox.Width, Integer.MaxValue), TextFormatFlags.WordBreak Or TextFormatFlags.TextBoxControl)
        Try
            TextBox.ScrollBar = If(textBoxRect.Height > TextBox.Height, ScrollBars.Vertical, ScrollBars.None)
        Catch ex As Exception
            'handle error
        End Try
    End Sub
