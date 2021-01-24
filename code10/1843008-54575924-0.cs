    foreach (object item in this.Items)
    {
        DataGridRow row = this.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
        if (row != null)
        {
            ComboBox cmb = FindVisualChildren<ComboBox>(row)?.FirstOrDefault();
            if (cmb != null)
            {
                string name = cmb.Text;
            }
        }
    }
