    public static class DataGridCellAttachedProperties
    {
        //Register new attached property
        public static readonly DependencyProperty IsSingleClickEditModeProperty =
            DependencyProperty.RegisterAttached("IsSingleClickEditMode", typeof(bool), typeof(DataGridCellAttachedProperties), new UIPropertyMetadata(false, OnPropertyIsSingleClickEditModeChanged));
        private static void OnPropertyIsSingleClickEditModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var dataGridCell = d as DataGridCell;
            if (dataGridCell == null)
                return;
            var isSingleEditMode = GetIsSingleClickEditMode(d);
            var behaviors =  Interaction.GetBehaviors(d);
            var singleClickEditBehavior = behaviors.SingleOrDefault(x => x is SingleClickEditDataGridCellBehavior);
            
            if (singleClickEditBehavior != null && !isSingleEditMode)
                behaviors.Remove(singleClickEditBehavior);
            else if (singleClickEditBehavior == null && isSingleEditMode)
            {
                singleClickEditBehavior = new SingleClickEditDataGridCellBehavior();
                behaviors.Add(singleClickEditBehavior);
            }
        }
        public static bool GetIsSingleClickEditMode(DependencyObject obj)
        {
            return (bool) obj.GetValue(IsSingleClickEditModeProperty);
        }
        public static void SetIsSingleClickEditMode(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSingleClickEditModeProperty, value);
        }
    }
