     Private Sub txtSmartDate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSmartDate.TextChanged
        If Not Me.DesignMode Then
            If _ValueInitialised And Not _SuppressEventCode Then
                '   Apply the changes to the property value, now the text box has been updated.
                Call SetPropertyValues()
                Call ApplyDateFormating()
            End If
        End If
    End Sub
