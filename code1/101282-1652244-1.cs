          Private Sub GridView1_OnRowDataBound(ByVal sender as Object, ByVal e as EventArgs)
               If e.Row.RowType = DataControlRowType.DataRow Then
                  'in this example the column in question is the 3rd column
                  'unless you are doing some javascript or some css on the label, I would 
                  'recommend using a literal and not label.  This is presuming there is no               
                  'label or literal control in the ItemTemplate property of the TemplateColumn
                  Dim lt as New Literal
                  lt.Text = NameController.GetName(e.Row.DataItem("NameID")) 'your business logic layer goes here
                  e.Row.Cells(2).Controls.Add(lt)
               End If
            End Sub
