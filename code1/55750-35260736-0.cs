        Dim t = TryCast(sender, ToolStripMenuItem)
        If Not t Is Nothing Then
            'Since you may have more On/off-Items, check to see if the Owner is the ContextMenuStrip 
            If t.Owner Is ctxWildCards Then
               ' The ContextMenuStrip will stay open on Right-click, i.e. the user can check and close by clicking 'normally'
                ctxWildCards.AutoClose = (e.Button = Windows.Forms.MouseButtons.Left)
            End If
            'Just me using a custom image for checked items.
            t.Checked = Not t.Checked
            t.Image = If(t.Checked, rdoImage, Nothing)
        End If
