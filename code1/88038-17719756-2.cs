    Public Class TextBoxScrollbarPlugin
        Private WithEvents mTarget As TextBox
        ''' <summary>
        ''' After the Handle is created, mTarget.IsHandleCreated always returns
        ''' TRUE, even after HandleDestroyed is fired.
        ''' </summary>
        ''' <remarks></remarks>
        Private mIsHandleCreated As Boolean = False
        Public Sub New(item As TextBox)
            mTarget = item
            mIsHandleCreated = mTarget.IsHandleCreated
        End Sub
        Private Sub Update()
            If Not mTarget.IsHandleCreated Then
                Return
            ElseIf Not mIsHandleCreated Then
                Return
            End If
            Dim textBoxRect = TextRenderer.MeasureText(mTarget.Text,
                                                       mTarget.Font,
                                                       New Size(mTarget.Width, Integer.MaxValue),
                                                       TextFormatFlags.WordBreak + TextFormatFlags.TextBoxControl)
            If textBoxRect.Height > mTarget.Height Then
                mTarget.ScrollBars = ScrollBars.Vertical
            Else
                mTarget.ScrollBars = ScrollBars.None
            End If
        End Sub
        Private Sub mTarget_HandleCreated(sender As Object, e As System.EventArgs) Handles mTarget.HandleCreated
            mIsHandleCreated = True
        End Sub
        Private Sub mTarget_HandleDestroyed(sender As Object, e As System.EventArgs) Handles mTarget.HandleDestroyed
            mIsHandleCreated = False
        End Sub
        Private Sub mTarget_SizeChanged(sender As Object, e As System.EventArgs) Handles mTarget.SizeChanged
            Update()
        End Sub
        Private Sub mTarget_TextChanged(sender As Object, e As System.EventArgs) Handles mTarget.TextChanged
            Update()
        End Sub
    End Class
