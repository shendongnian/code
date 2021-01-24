    private void ListViewStories_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        // This line null checks the object and also gives you a reference
        if (e.SelectedItem is Story story)
        {
            DisplayAlert($"Title -> {story.Title}   Date -> {story.Date}", "Cancel");
            // Deselect the cell that was tapped
            listViewStories.SelectedItem = null;
        }
    }
