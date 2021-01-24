 	Using NotesDS As New DataSet
            Using NotesDA As New SqlDataAdapter With {.SelectCommand = New SqlCommand With {.Connection = SQLDBConnection, .CommandText = "SELECT * FROM Notes WHERE ID = " & ID}}
                NotesDA.Fill(NotesDS, "Notes")
                Using NotesDV As New DataView(NotesDS.Tables("Notes"))
                    Using NoteBuilder As New SqlCommandBuilder(NotesDA) With {.QuotePrefix = "[", .QuoteSuffix = "]"}                        
                        If NotesDV.Count = 1 Then                             
                            Dim NoteDRV As DataRowView = NotesDV(0)
                            NoteDRV.BeginEdit()
                            NoteDRV.Item("UserName") = UserName
                            NoteDRV.Item("Note") = Note
                            NoteDRV.Item("NoteDate") = NoteDate
                            NoteDRV.Item("CompanyCode") = CompanyCode
                            NoteDRV.EndEdit()
                            NotesDA.UpdateCommand = NoteBuilder.GetUpdateCommand
                            NotesDA.Update(NotesDS, "Notes")
                        End If
                    End Using
                End Using
            End Using
        End Using
