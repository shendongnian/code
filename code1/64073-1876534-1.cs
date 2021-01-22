    for (int i = 0; i < yourItemsControl.Items.Count; i++)
    {
        ContentPresenter c = (ContentPresenter)yourItemsControl.ItemContainerGenerator.ContainerFromItem(yourItemsControl.Items[i]);
        ToggleButton tb = c.ContentTemplate.FindName("btnYourButtonName", c) as ToggleButton;
        if (tb.IsChecked.Value)
        {
            //do stuff
        }
    }
