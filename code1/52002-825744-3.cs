       Protected Sub gvDocs_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvDocs.PreRender
    
            If gvDocs.Rows.Count > 0 Then
    
    
                Dim m As Integer = gvDocs.FooterRow.Cells.Count
                For i As Integer = m - 1 To 1 Step -1
                    If i <> 8 Then '7 is the number of the column with the applychanges button in it.
                        gvDocs.FooterRow.Cells.RemoveAt(i)
                    End If
                Next i
                gvDocs.FooterRow.Cells(1).ColumnSpan = 6 '6 is the number of visible columns to span.
            End If
        End Sub
