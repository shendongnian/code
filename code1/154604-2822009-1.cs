    private void DockPanel_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
      var element = (FrameworkElement)sender;
      if(element.IsKeyboardFocusWithin)
      {
        Visual cur = element;
        while(cur!=null && !(cur is ListBoxItem))
          cur = (Visual)VisualTreeHelper.GetParent(cur);
        ((ListBoxItem)cur).IsSelected = true;
      }
    }
    private void DockPanel_MouseDown(object sender, MouseEventArgs e)
    {
      ((FrameworkElement)sender).MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
    }
    private void InitializeView()
    {
      var view = CollectionViewSource.GetDefaultView(Parameters);
      if(view.GroupDescriptions.Count==0)
        view.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
      if(view.SortDescriptions.Count==0)
      {
        view.SortDescriptions.Add(new SortDescription("Category", ListSortDirection.Ascending));
        view.SortDescriptions.Add(new SortDescription("DisplayName", ListSortDirection.Ascending));
      }
    }
