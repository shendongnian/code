        public class EditCellOnSingleClick : Behavior<DataGrid>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                this.AssociatedObject.LoadingRow += this.OnLoadingRow;
                this.AssociatedObject.UnloadingRow += this.OnUnloading;
            }
            protected override void OnDetaching()
            {
                base.OnDetaching();
                this.AssociatedObject.LoadingRow -= this.OnLoadingRow;
                this.AssociatedObject.UnloadingRow -= this.OnUnloading;
            }
            private void OnLoadingRow(object sender, DataGridRowEventArgs e)
            {
                e.Row.GotFocus += this.OnGotFocus;
            }
            private void OnUnloading(object sender, DataGridRowEventArgs e)
            {
                e.Row.GotFocus -= this.OnGotFocus;
            }
            private void OnGotFocus(object sender, RoutedEventArgs e)
            {
                this.AssociatedObject.BeginEdit(e);
            }
        }
