    public bool IsItemVisible(ListBox listBox, int index)
    {
        if (listBox.Items.Count != 0)
        {
            VirtualizingStackPanel vsp = (VirtualizingStackPanel)VisualTreeHelper.GetParent(listBox.ItemContainerGenerator.ContainerFromIndex(0));
            int FirstVisibleItem = (int)vsp.VerticalOffset, VisibleItemCount = (int)vsp.ViewportHeight;
            return index >= FirstVisibleItem && index <= FirstVisibleItem + VisibleItemCount;
        }
    
        return false;
    }
