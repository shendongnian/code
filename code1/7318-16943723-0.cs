    Private Sub DocumentEvents_DocumentOpened(ByVal Document As EnvDTE.Document) Handles DocumentEvents.DocumentOpened
        If (Not Document Is Nothing) Then
            If (Document.FullName.ToLower().EndsWith(".cs")) Then
                Try
                    DTE.ExecuteCommand("Edit.ExpandAllOutlining")
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub
    Private Sub WindowEvents_WindowActivated(ByVal GotFocus As EnvDTE.Window, ByVal LostFocus As EnvDTE.Window) Handles WindowEvents.WindowActivated
        If (Not GotFocus Is Nothing) Then
            If (Not GotFocus.Document Is Nothing) Then
                If (GotFocus.Document.FullName.ToLower().EndsWith(".cs")) Then
                    Try
                        DTE.ExecuteCommand("Edit.ExpandAllOutlining")
                    Catch ex As Exception
                    End Try
                End If
            End If
        End If
    End Sub
