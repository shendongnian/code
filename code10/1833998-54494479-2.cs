    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    namespace WpfApp1
    {
        public class ScrollToSyncValueBehavior : Behavior<DataGrid>
        {
            protected override void OnAttached()
            {
                this.AssociatedObject.IsVisibleChanged += OnVisibleChanged;
            }
            protected override void OnDetaching()
            {
                this.AssociatedObject.IsVisibleChanged -= OnVisibleChanged;
            }
            private static void OnVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                if (sender is DataGrid dataGrid && dataGrid.IsVisible)
                {
                    ISync viewModel = dataGrid.DataContext as ISync;
                    if (viewModel?.SyncValue != null)
                        dataGrid.ScrollIntoView(viewModel.SyncValue);
                }
            }
        }
    }
