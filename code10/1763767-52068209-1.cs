	Html
	.BeginTable()
	.NewRow()
	.Label(Html, "MyCssClass", Model, "FieldName1")
	.NewColumn()
	.Label(Html, "MyCssClass", Model, "FieldName2")
	.EndRow()
	.EndTable();
	
	
	Html.BeginTable().NewRow()
	.Label(Html, "MyCssClass", Model, "FieldName1")
	.NewColumn()
	.Label(Html, "MyCssClass", Model, "FieldName2")
	.EndRow().EndTable();
