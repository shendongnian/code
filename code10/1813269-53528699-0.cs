    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    
    namespace MyNamespace
    {
        /// <summary>
        /// Creates the correct behavior when tabbing out of a new row in a DataGrid.
        /// https://peplowdown.wordpress.com/2012/07/19/wpf-datagrid-moves-input-focus-and-selection-to-the-wrong-cell-when-pressing-tab/
        /// </summary><remarks>
        /// You’d expect that when you hit tab in the last cell the WPF data grid it would create a new row and put your focus in the first cell of that row. 
        /// It doesn’t; depending on how you have KeboardNavigation.TabNavigation set it’ll jump off somewhere you don’t expect, like the next control 
        /// or back to the first item in the grid.  This behavior class solves that problem.
        /// </remarks>
        public class NewLineOnTabBehavior : Behavior<DataGrid>
        {
            private bool _monitorForTab;
    
            protected override void OnAttached()
            {
                base.OnAttached();
                AssociatedObject.BeginningEdit += _EditStarting;
                AssociatedObject.CellEditEnding += _CellEnitEnding;
                AssociatedObject.PreviewKeyDown += _KeyDown;
            }
    
            private void _EditStarting(object sender, DataGridBeginningEditEventArgs e)
            {
                if (e.Column.DisplayIndex == AssociatedObject.Columns.Count - 1)
                    _monitorForTab = true;
            }
    
            private void _CellEnitEnding(object sender, DataGridCellEditEndingEventArgs e)
            {
                _monitorForTab = false;
            }
    
            private void _KeyDown(object sender, KeyEventArgs e)
            {
                if (_monitorForTab && e.Key == Key.Tab)
                {
                    AssociatedObject.CommitEdit(DataGridEditingUnit.Row, false);
                }
            }
    
            protected override void OnDetaching()
            {
                base.OnDetaching();
                AssociatedObject.BeginningEdit -= _EditStarting;
                AssociatedObject.CellEditEnding -= _CellEnitEnding;
                AssociatedObject.PreviewKeyDown -= _KeyDown;
                _monitorForTab = false;
            }
        }
    }
