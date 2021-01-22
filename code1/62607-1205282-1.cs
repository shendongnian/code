    private void OnItemContainerGeneratorStatusChanged(object sender, EventArgs e)
    {
      if (_events.ItemContainerGenerator.Status!=GeneratorStatus.ContainersGenerated)
        return;
      for (int i = 0; i < _viewModel.Events.Count; i++)
      {
        // Get the container that wraps the item from ItemsSource
        var item = (ListBoxItem)_events.ItemContainerGenerator.ContainerFromIndex(i);
        // May be null if filtered
        if (item == null)
          continue;
        // Find the target
        var textBlock = item.FindByName("ActualText");
        // Find the data item to which the data template was applied
        var eventViewModel = (EventViewModel)textBlock.DataContext;
        // This is the path I want to bind to
        var path = eventViewModel.BindingPath;
        // Create a binding
        var binding = new Binding(path) { Source = eventViewModel };
        textBlock.SetBinding(TextBlock.TextProperty, binding);
      }
    }
