	private void addSection(Section section)
	{
		section.Loaded += section_Loaded;
		fdoc.Blocks.Add(section);
	}
	private void section_Loaded(object sender, RoutedEventArgs e)//scroll to end
	{
		var sec = sender as Section;
		if (sec != null)
		{
			sec.BringIntoView();
		}
	}
