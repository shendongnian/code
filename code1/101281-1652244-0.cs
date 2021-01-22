    Private Sub GridView1_OnRowDataBound(ByVal sender as Object, ByVal e as EventArgs)
       If e.Row.RowType = DataControlRowType.DataRow Then
          'in this example the column in question is the 3rd column
          Dim lt as New Literal
          lt.Text = NameController.GetName(e.Row.DataItem("NameID")) 'your business logic layer goes here
          e.Row.Cells(2).Controls.Add(lt)
       End If
    End Sub
