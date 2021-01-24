        If DGV.SelectedRows.Count > 0 Then
           Try
            ' SQL part: '
            Dim selectedRow = DGV.Rows(e.RowIndex).Cells(0).Value.ToString()
            connection.Open()
            Dim query as String = "DELETE FROM tablename WHERE [columnname] = @selectedRow "
            Dim cmd as New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@selectedRow",selectedRow)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Data Deleted !")
            connection.Close()
            ' DGV part: '
            Dim Row As Integer = DGV.CurrentCell.RowIndex
            DGV.Rows.RemoveAt(Row)
           Catch ex As Exception
             MsgBox(ex.Message)
           End Try
        Else
            MsgBox("Select an element.")
        End If
