    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        MyBase.OnLoad(e)
        Dim page As New Page
        Dim path As String = request.ApplicationPath
        Dim control as UI.Control = page.LoadControl(String.Format _
            ("{0}/pathToUserControl/{1}.ascx", path, controlName))
        Dim sc As ISpiffyControl = CType(control, ISpiffyControl)
        sc.DoSomethingSpecial()
        Me.Controls.Add(sc)
    End Sub
