    Private Sub MenuStrip_ItemAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemEventArgs) Handles MenuStrip.ItemAdded
            Dim s As New String(e.Item.GetType().ToString())
            If s = "System.Windows.Forms.MdiControlStrip+SystemMenuItem" Then
                e.Item.Visible = False
            End If
        End Sub
