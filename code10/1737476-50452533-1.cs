	protected void Page_Load()
	{
		//Load the file
		doc = new PdfDocument(pdfFileName);
		//Get all fields
		fields = doc.Fields;
		if (!IsPostBack)
		{
			CreateForm();
		}
		else
		{
			RecreateForm();
		}
	}
	private void CreateForm()
	{
		Dictionary<Guid, string> tempList = new Dictionary<Guid, string>();
		Dictionary<Guid, string> tempNames = new Dictionary<Guid, string>();
		foreach (PdfField field in fields)
		{
			//Only display the text fields
			if (field.GetType() == typeof(PdfTextField))
			{
				TableRow tr = new TableRow();
				TableCell name = new TableCell
				{
					Text = field.Name
				};
				tr.Cells.Add(name);
				TableCell options = new TableCell();
				DropdownList dropdown = (DropdownList)LoadControl("~/DropdownList.ascx");
				Guid nextKey = Guid.NewGuid();
				tempList[nextKey] = "dropdown" + nextKey.ToString().Replace('-', '_');
				dropdown.ID = tempList[nextKey];
				tempNames[nextKey] = field.Name;
				options.Controls.Add(dropdown);
				tr.Cells.Add(options);
				Table1.Rows.Add(tr);
			}
		}
		DropdownLists = tempList;
		DropdownNames = tempNames;
	}
	private void RecreateForm()
	{
		foreach (var item in DropdownLists)
		{
			TableRow tr = new TableRow();
			TableCell name = new TableCell
			{
				Text = DropdownNames[item.Key]
			};
			tr.Cells.Add(name);
			TableCell options = new TableCell();
			DropdownList dropdown = (DropdownList)LoadControl("~/DropdownList.ascx");
			dropdown.ID = DropdownLists[item.Key];
			options.Controls.Add(dropdown);
			tr.Cells.Add(options);
			Table1.Rows.Add(tr);
		}
	}
