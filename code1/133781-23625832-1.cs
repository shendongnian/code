    Protected Overrides Sub OnEnter(e As EventArgs)
        MyBase.OnEnter(e)
        Me.highlightImage()
    End Sub
    Protected Overrides Sub OnLeave(e As EventArgs)
        MyBase.OnLeave(e)
        MyBase.Refresh()
    End Sub
