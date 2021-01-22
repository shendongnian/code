    ListBoxItem myListBoxItem = (ListBoxItem)(lstUniqueIds.ItemContainerGenerator.ContainerFromIndex(lstUniqueIds.SelectedIndex));
    ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
                    DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
                    CheckBox target = (CheckBox)myDataTemplate.FindName("chkUniqueId", myContentPresenter);
                    if (target.IsChecked == true)
                    {
                        target.IsChecked = false;
                    }
                    else
                    {
                        target.IsChecked = true;
                    }
