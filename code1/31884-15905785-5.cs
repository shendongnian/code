        Private Sub DisableControls(control As System.Web.UI.Control)
            For Each c As System.Web.UI.Control In control.Controls
                ' Get the Enabled property by reflection.
                Dim type As Type = c.GetType
                Dim prop As PropertyInfo = type.GetProperty("Enabled")
                ' Set it to False to disable the control.
                If Not prop Is Nothing Then
                    prop.SetValue(c, False, Nothing)
                End If
                ' Recurse into child controls.
                If c.Controls.Count > 0 Then
                    Me.DisableControls(c)
                End If
            Next
        End Sub
