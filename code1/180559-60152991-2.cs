    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    namespace YourMainViewModelNameSpace
    {
        public static class DataGridTextBoxSingleClickEditBehavior
        {
            public static readonly DependencyProperty EnableProperty = DependencyProperty.RegisterAttached(
                "Enable",
                typeof(bool),
                typeof(DataGridTextBoxSingleClickEditBehavior),
                new FrameworkPropertyMetadata(false, OnEnableChanged));
    
    
            public static bool GetEnable(FrameworkElement frameworkElement)
            {
                return (bool) frameworkElement.GetValue(EnableProperty);
            }
    
    
            public static void SetEnable(FrameworkElement frameworkElement, bool value)
            {
                frameworkElement.SetValue(EnableProperty, value);
            }
    
    
            private static void OnEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (d is DataGridCell dataGridCell)
                    dataGridCell.PreviewMouseLeftButtonDown += DataGridCell_PreviewMouseLeftButtonDown;
            }
    
    
            private static void DataGridCell_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                EditCell(sender as DataGridCell, e);
            }
    
            private static void EditCell(DataGridCell dataGridCell, RoutedEventArgs e)
            {
                if (dataGridCell == null || dataGridCell.IsEditing || dataGridCell.IsReadOnly)
                    return;
    
                if (dataGridCell.IsFocused == false)
                    dataGridCell.Focus();
    
                var dataGrid = FindVisualParent<DataGrid>(dataGridCell);
                dataGrid?.BeginEdit(e);
            }
    
    
            private static T FindVisualParent<T>(UIElement element) where T : UIElement
            {
                var parent = VisualTreeHelper.GetParent(element) as UIElement;
    
                while (parent != null)
                {
                    if (parent is T parentWithCorrectType)
                        return parentWithCorrectType;
    
                    parent = VisualTreeHelper.GetParent(parent) as UIElement;
                }
    
                return null;
            }
        }
    }
