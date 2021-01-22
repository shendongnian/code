        private void stackPanel_ContextMenuOpening(
            object sender, ContextMenuEventArgs e)
        {
            StackPanel sp = sender as StackPanel;
            if (sp != null)
            {
                // solutionItem is the "context"
                ISolutionItem solutionItem =
                    sp.DataContext as ISolutionItem;
                if (solutionItem != null) 
                {
                    IEnumerable<IMenuItem> items = 
                        solutionItem.ContextMenu as IEnumerable<IMenuItem>;
                    if (items != null)
                    {
                        foreach (IMenuItem item in items)
                        {
                            // will automatically set all 
                            // child menu items' context as well
                            item.Context = solutionItem;
                        }
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = true;
            }
        }
