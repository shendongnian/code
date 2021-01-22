	class ColouredCheckedListBox : CheckedListBox
	{
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			DrawItemEventArgs e2 =
				new DrawItemEventArgs
				(
					e.Graphics,
					e.Font,
					new Rectangle(e.Bounds.Location, e.Bounds.Size),
					e.Index,
					e.State,
					e.ForeColor,
					this.CheckedIndices.Contains(e.Index) ? Color.Red : SystemColors.Window
				);
			base.OnDrawItem(e2);
		}
	}
