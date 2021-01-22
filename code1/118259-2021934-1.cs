    Protected Sub SubmitButton_Click(ByVal sender As Object, ByVal args As EventArgs)
        If Me.EnabledTrue.Checked Then
            If ((Me.TxtAlias.Text Is Nothing) OrElse (Me.TxtAlias.Text.Length = 0)) Then
                Throw New SPException(SPResource.GetString("MissingEmailAlias", New Object(0  - 1) {}))
            End If
            'This will be the receiving e-mail address
            Me.m_List.EmailAlias = Me.TxtAlias.Text
            'do we need to check users permissions on items
            Me.m_RootFolder.Properties.Item("vti_emailusesecurity") = IIf(Me.UseSecurityTrue.Checked, 1, 0)
            If Me.ShowSaveAttachments Then
                'options how to save attachments, root folder, grouped, whatever
                Me.m_RootFolder.Properties.Item("vti_emailsaveattachments") = IIf(Me.SaveAttachmentsTrue.Checked, 1, 0)
            End If
            If Me.ShowSaveOriginalAndMeetings Then
                Me.m_RootFolder.Properties.Item("vti_emailsavemeetings") = IIf(Me.MeetingsTrue.Checked, 1, 0)
                Me.m_RootFolder.Properties.Item("vti_emailsaveoriginal") = IIf(Me.SaveOriginalTrue.Checked, 1, 0)
            End If
            If Me.ShowAttachmentFolders Then
                Me.m_RootFolder.Properties.Item("vti_emailoverwrite") = IIf(Me.OverwriteTrue.Checked, 1, 0)
                If Me.AttachmentFoldersSender.Checked Then
                    Me.m_RootFolder.Properties.Item("vti_emailattachmentfolders") = "sender"
                ElseIf Me.AttachmentFoldersSubject.Checked Then
                    Me.m_RootFolder.Properties.Item("vti_emailattachmentfolders") = "subject"
                Else
                    Me.m_RootFolder.Properties.Item("vti_emailattachmentfolders") = "root"
                End If
            End If
            If Me.ShowAutoApprove Then
                'I think this is something when content approval is enabled.
                Me.m_RootFolder.Properties.Item("vti_emailautoapprove") = IIf(Me.AutoApproveTrue.Checked, 1, 0)
            End If
        ElseIf Me.EnabledFalse.Checked Then
            Me.m_List.EmailAlias = Nothing
        End If
        Me.m_RootFolder.Update
        Me.m_List.ResetContentTypes
        Me.m_List.Update
        SPUtility.Redirect((IIf((Me.m_List.BaseType = SPBaseType.Survey), "survedit", "listedit") & ".aspx?List=" & Me.m_List.ID.ToString), SPRedirectFlags.RelativeToLocalizedLayoutsPage, Me.Context)
    End Sub
    
     
