	protected virtual void OnDrawItem(object sender, DrawItemEventArgs e)
	{
		var comboBox = sender as ComboBox;
		if (comboBox == null)
		{
			return;
		}
		e.DrawBackground();
		if (e.Index >= 0)
		{
			StringFormat sf = new StringFormat();
			sf.LineAlignment = StringAlignment.Center;
			sf.Alignment = StringAlignment.Center;
			Brush brush = new SolidBrush(comboBox.ForeColor);
			if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
			{
				brush = SystemBrushes.HighlightText;
			}
			e.Graphics.DrawString(comboBox.Items[e.Index].ToString(), comboBox.Font, brush, e.Bounds, sf);
		}
	}
