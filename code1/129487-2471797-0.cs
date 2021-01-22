    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        //Code to generate the data (stripped out because it is generated in a different manner than the original poster)
        //Add events for all of the new-found controls depending on their type
        recursiveAddEvents(nameOfPlaceHolder.Controls)
    End Sub
    //Add events for all of the new-found controls depending on their type
    Sub recursiveAddEvents(ByRef controls As ControlCollection)
        For Each con As Control In controls
            If con.Controls.Count > 0 Then
                recursiveAddEvents(con.Controls)
            End If
            //Try to cast the control to different data types
            Dim btn As Button = TryCast(con, Button)
            Dim file As FileUpload = TryCast(con, FileUpload)
            //Test to see which type the control was and apply the actions to it
            If Not btn Is Nothing Then
                //Assign the correct click events
                If btn.Attributes.Item("action") = "addVersion" Then
                    AddHandler btn.Click, AddressOf addDraftVersion
                    btn.ID = btn.Attributes.Item("identity")
                    //Register the control with the ScriptManager
                    ScriptManager.GetCurrent(Page).RegisterPostBackControl(btn)
                End If
            ElseIf Not file Is Nothing Then
                //Assign the correct click events
                file.ID = file.Attributes.Item("identity")
            End If
        Next
    End Sub
    Protected Sub addDraftVersion(ByVal sender As Button, ByVal e As EventArgs)
        Dim fileName as String = sender.Attributes("title").Replace(" ", "_") & "_D" & info("draftID") & "_V" & info("versionID")
        Dim inputControl As FileUpload = TryCast(trackPH.FindControl(sender.Attributes("fileControlIdentity")), FileUpload)
        If inputControl Is Nothing Then
            Exit Sub
        End If
        //Do whatever need to be done
        //Trigger UpdatePanel(s)
        nameOfUpdatePanel.Update()
    End Sub
