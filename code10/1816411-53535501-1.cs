    using System;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    namespace wpf_EntityFramework
    {
        class ScrollDataGridRowIntoView : Behavior<DataGrid>
        {
            protected override void OnAttached()
            {
                base.OnAttached();
                this.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
            }
            void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                if (sender is DataGrid)
                {
                    DataGrid datagrid = (sender as DataGrid);
                    if (datagrid.SelectedItem != null)
                    {
                        datagrid.Dispatcher.BeginInvoke((Action)(() =>
                        {
                            datagrid.UpdateLayout();
                            if (datagrid.SelectedItem != null)
                            {
                                datagrid.ScrollIntoView(datagrid.SelectedItem);
                            }
                        }));
                    }
                }
            }
            protected override void OnDetaching()
            {
                base.OnDetaching();
                this.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
            }
        }
    }
