    Protected Sub myODS_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles myODS.Selected
        Dim s As String = e.ReturnValue.ToString
        Dim rows As Integer
        Int32.TryParse(s, rows)
		'rows variable now holds the total number of results, not just what's displayed on the current gridview page
	End Sub
