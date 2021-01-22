    Protected Sub gridName_PreRender(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim grd As CustomControls.GridViewColGroup = sender
        Dim wctrl As New WebControl(HtmlTextWriterTag.Col)
        wctrl.CssClass = "some_class_m"
        grd.ColGroup.Controls.Add(wctrl)
    End Sub
