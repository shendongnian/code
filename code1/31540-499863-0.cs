    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    
        // Create the listView
        Dim lstView As New ListView()
        lstView.Dock = DockStyle.Fill
        lstView.Items.Add("item 1") //item added for test
        lstView.Items.Add("item 2") //item added for test
    
        // Create the new tab page
        Dim tab As New TabPage("next tab")
        tab.Controls.Add(lstView) // Add the listview to the tab page
    
        // Add the tabpage to the existing TabCrontrol
        Me.TabControl1.TabPages.Add(tab)
    
    End Sub
