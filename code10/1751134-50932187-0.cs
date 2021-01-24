    ContentPresenter c = (ContentPresenter)itemsControl.ItemContainerGenerator.ContainerFromIndex(i);
    TextBox t2 = c.ContentTemplate.FindName("textboxName", c) as TextBox;
    if (t2 != null)
    {
        t2.Focus();
        t2.SelectAll();
    }
