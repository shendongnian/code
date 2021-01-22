    public class NoBindingGroupGrid
        : DataGrid
    {
        protected override Size MeasureOverride(Size availableSize)
        {
            var desiredSize = base.MeasureOverride(availableSize);
            ClearBindingGroup();
            return desiredSize;
        }
        private void ClearBindingGroup()
        {
            // Clear ItemBindingGroup so it isn't applied to new rows
            ItemBindingGroup = null;
            // Clear BindingGroup on already created rows
            foreach (var item in Items)
            {
                var row = ItemContainerGenerator.ContainerFromItem(item) as FrameworkElement;
                row.BindingGroup = null;
            }
        }
    }
