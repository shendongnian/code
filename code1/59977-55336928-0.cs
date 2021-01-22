	public void SelectAll()
	{
		bool prevBusy = MouseHelper.IsBusy;
		MouseHelper.IsBusy = true;
		int topIndex = TopIndex;
		// BUG: In 'SelectionMode.MultiExtended' the box gets crazy
		SelectionMode previousMode = this.SelectionMode;
		this.SelectionMode = SelectionMode.MultiSimple;
		this.BeginUpdate();
		for (int i = 0; i < Items.Count; i++)
		{
			SelectedIndices.Add(i);
		}
		this.EndUpdate();
		this.SelectionMode = previousMode;
		TopIndex = topIndex;
		MouseHelper.IsBusy = prevBusy;
	}
