        Protected Sub Page_SaveStateComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SaveStateComplete
            Dim DG As GridView = GridView1
                Dim Tbl As Table = DG.Controls(0)
                Dim tr As GridViewRow
                Dim i As Integer
                Dim j As Integer
    
    tr = Tbl.Rows(Tbl.Rows.Count - 1) 'this line assume last row is footer row
    
                        tr.Cells(0).ColumnSpan = 2 'if you have 3 columns then colspan = 3 instead
    
                        For j = 1 To 1 'if you have 3 columns then j = 1 To 2 instead
                            tr.Cells(j).Visible = False
                        Next
    
        End Sub
