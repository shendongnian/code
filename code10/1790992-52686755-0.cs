    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media;
    
    namespace Nagasaki
    {
        public static class Datagrid
        {
            public static DataGridRow GetSelectedRow(this DataGrid grid)
            {
                return (DataGridRow)grid.ItemContainerGenerator.ContainerFromItem(grid.SelectedItem);
            }
            public static DataGridRow GetRow(this DataGrid grid, int index)
            {
                DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
                if (row == null)
                {
                    // May be virtualized, bring into view and try again.
                    grid.UpdateLayout();
                    grid.ScrollIntoView(grid.Items[index]);
                    row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
                }
                return row;
            }
            public static DataGridCell GetCell(this DataGrid grid, DataGridRow row, int column)
            {
                if (row != null)
                {
                    DataGridCellsPresenter presenter = GetVisualChild<DataGridCellsPresenter>(row);
    
                    if (presenter == null)
                    {
                        grid.ScrollIntoView(row, grid.Columns[column]);
                        presenter = GetVisualChild<DataGridCellsPresenter>(row);
                    }
    
                    DataGridCell cell = (DataGridCell)presenter.ItemContainerGenerator.ContainerFromIndex(column);
                    return cell;
                }
                return null;
            }
    
            public static T GetVisualChild<T>(Visual parent) where T : Visual
            {
                T child = default(T);
                int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < numVisuals; i++)
                {
                    Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                    child = v as T;
                    if (child == null)
                    {
                        child = GetVisualChild<T>(v);
                    }
                    if (child != null)
                    {
                        break;
                    }
                }
                return child;
            }
            public static DataGridCell GetCell(this DataGrid grid, int row, int column)
            {
                DataGridRow rowContainer = GetRow(grid, row);
                return GetCell(grid, rowContainer, column);
            }
    
        }
    }
