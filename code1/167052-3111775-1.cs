    Private Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
            If Me.TabContainer1.ActiveTab Is Me.TabLocation Then
                Me.MasterDataType = "Locations"
            End If
            switchControlVisibility()
        End Sub
    
        Private Sub switchControlVisibility()
            Select Case Me.MasterDataType.ToLower
                Case "locations"
                    Me.MD_Location.Visible = True
                    Me.Lblheader2.Text = "Locations"
                    UpdHeader.Update()
                    Me.MD_Location.BindData() '<---- do  time-consuming  stuff
                    Me.UpdLocation.Update()   
           
        End Sub
