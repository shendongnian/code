    private void TextBlockLoaded(object sender, RoutedEventArgs e)
    {
        var textBlockAP = FrameworkElementAutomationPeer.CreatePeerForElement(sender as UIElement);
        if (textBlockAP != null) 
        {
            var parentAP = textBlockAP.Navigate(AutomationNavigationDirection.Parent);
            if (parentAP is GridViewHeaderItemAutomationPeer gridViewHeaderItemAP)
            {
                var gridViewHeaderItem = gridViewHeaderItemAP.Owner as GridViewHeaderItem;
                var itemGroup = gridViewHeaderItem.Content as SomeItemGroupClass;
                AutomationProperties.SetName(gridViewHeaderItem, itemGroup.Title ?? string.Empty);
            }
        }
    }
