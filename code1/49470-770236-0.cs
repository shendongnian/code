	public override void InitializeCell(TableCell cell, int columnIndex, ListItemType itemType)
	{
		base.InitializeCell(cell, columnIndex, itemType);
		if ((itemType != ListItemType.Header) && (itemType != ListItemType.Footer))
		{
			WebControl child = null;
			if (this.ButtonType == ButtonColumnType.LinkButton)
				...
			else
			{
				child = new Button {
					Text = this.Text,
					CommandName = this.CommandName,
					CausesValidation = this.CausesValidation,
					ValidationGroup = this.ValidationGroup
				};
			}
			...
			cell.Controls.Add(child);
		}
	}
