	private void OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
	{
		if (UnitStrings.ContainsKey(e.PropertyType))
			e.Column.HeaderStringFormat = $"{{0}} ({UnitStrings[e.PropertyType]})";
	}
