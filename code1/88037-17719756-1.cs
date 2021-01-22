    Public Class TextBoxScrollbarPlugin
        Private WithEvents mTarget As TextBox
        Public Sub New(item As TextBox)
            mTarget = item
        End Sub
        Private Sub Update()
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
        Private Sub mTarget_SizeChanged(sender As Object, e As System.EventArgs) Handles mTarget.SizeChanged
            Update()
        End Sub
        Private Sub mTarget_TextChanged(sender As Object, e As System.EventArgs) Handles mTarget.TextChanged
            Update()
        End Sub
    End Class
    
    Private mPlugins As New List(Of Object)
    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mPlugins.Add(New TextBoxScrollbarPlugin(txtBoxOne))
        mPlugins.Add(New TextBoxScrollbarPlugin(txtBoxTwo))
        mPlugins.Add(New TextBoxScrollbarPlugin(txtBoxThree))
    End Sub    
