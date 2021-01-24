    protected void Load_Section1()
    {
        section1.Items.Clear();
		
        section1.Items.Add(new ListItem("--- Select Section ---", "0"));
		
		Guid topicId;
		if (Guid.TryParse(topic1.SelectedValue, out topicId))
		{
			var sectionStore = new SectionStore();
			var sections = sectionStore.ReadForTopic(topicId);
			foreach (var section in sections)
			{
				var sectionListItem = new ListItem(section.Name, section.Id.ToString());
				section1.Items.Add(sectionListItem);
			}
		}
    }
