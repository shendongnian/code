    public class SelectRowOnRightClickBehavior : Behavior<DataGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.MouseRightButtonDown += HandleRightButtonClick;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.MouseRightButtonDown += HandleRightButtonClick;
        }
        private void HandleRightButtonClick(object sender, MouseButtonEventArgs e)
        {
            var elementsUnderMouse = VisualTreeHelper.FindElementsInHostCoordinates(e.GetPosition(null), AssociatedObject);
            var row = elementsUnderMouse
                .OfType<DataGridRow>()
                .FirstOrDefault();
            if (row != null)
                AssociatedObject.SelectedItem = row.DataContext;
        }
    }
