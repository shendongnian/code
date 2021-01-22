    void SetExpandedStateInView(bool isExpanded)
    {
        var model = this.DataContext as TreeViewModel;
        if (model == null)
        {
            // View model is not bound so do nothing.
            return;
        }
        // Grab hold of the current ItemsSource binding.
        var bindingExpression = this.TreeView.GetBindingExpression(
            ItemsControl.ItemsSourceProperty);
        if (bindingExpression == null)
        {
            return;
        }
        // Clear that binding.
        var itemsSourceBinding = bindingExpression.ParentBinding;
        BindingOperations.ClearBinding(
        this.TreeView, ItemsControl.ItemsSourceProperty);
        // Wait for the binding to clear and then set the expanded state of the view model.
        this.Dispatcher.BeginInvoke(
            DispatcherPriority.DataBind, 
            new Action(() => SetExpandedStateInModel(model.Items, isExpanded)));
        // Now rebind the ItemsSource.
        this.Dispatcher.BeginInvoke(
            DispatcherPriority.DataBind,
            new Action(
                () => this.TreeView.SetBinding(
                    ItemsControl.ItemsSourceProperty, itemsSourceBinding)));
    }
    void SetExpandedStateInModel(IEnumerable modelItems, bool isExpanded)
    {
        if (modelItems == null)
        {
            return;
        }
        foreach (var modelItem in modelItems)
        {
            var expandable = modelItem as IExpandableItem;
            if (expandable == null)
            {
                continue;
            }
            expandable.IsExpanded = isExpanded;
            SetExpandedStateInModel(expandable, isExpanded);
        }
    }
