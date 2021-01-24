    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using RowCollapsibleMCVE;
    
    namespace Extensions
    {
        [ValueConversion(typeof(bool), typeof(bool))]
        public class BooleanConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return !(bool)value;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return Binding.DoNothing;
            }
        }
    
        public class GridHelper : DependencyObject
        {
            #region Attached Property
    
            public static readonly DependencyProperty SyncCollapsibleRowsProperty =
                DependencyProperty.RegisterAttached(
                    "SyncCollapsibleRows",
                    typeof(Boolean),
                    typeof(GridHelper),
                    new FrameworkPropertyMetadata(false,
                        FrameworkPropertyMetadataOptions.AffectsRender,
                        new PropertyChangedCallback(OnSyncWithCollapsibleRows)
                    ));
    
            public static void SetSyncCollapsibleRows(UIElement element, Boolean value)
            {
                element.SetValue(SyncCollapsibleRowsProperty, value);
            }
    
            private static void OnSyncWithCollapsibleRows(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (d is Grid grid)
                {
                    grid.Loaded += SyncControlsInCollapsibleRows;
                    grid.Unloaded -= SyncControlsInCollapsibleRows;
                }
            }
    
            private static void SyncControlsInCollapsibleRows(object sender, RoutedEventArgs e)
            {
                SetBindingForControlsInCollapsibleRows((Grid)sender);
            }
    
            #endregion
    
            #region Logic
    
            private static IEnumerable<UIElement> GetChildrenFromPanels(IEnumerable<UIElement> elements)
            {
                Queue<UIElement> queue = new Queue<UIElement>(elements);
                while (queue.Any())
                {
                    var uiElement = queue.Dequeue();
                    if (uiElement is Panel panel)
                    {
                        foreach (UIElement child in panel.Children) queue.Enqueue(child);
                    }
                    else
                    {
                        yield return uiElement;
                    }
                }
            }
    
            private static IEnumerable<UIElement> ElementsInRow(Grid grid, int iRow)
            {
                var rowRootElements = grid.Children.OfType<UIElement>().Where(c => Grid.GetRow(c) == iRow);
    
                if (rowRootElements.Any(e => e is Panel))
                {
                    return GetChildrenFromPanels(rowRootElements);
                }
                else
                {
                    return rowRootElements;
                }
            }
    
            private static BooleanConverter MyBooleanConverter = new BooleanConverter();
    
            private static void SyncUIElementWithRow(UIElement uiElement, CollapsibleRow row)
            {
                BindingOperations.SetBinding(uiElement, UIElement.FocusableProperty, new Binding
                {
                    Path = new PropertyPath(CollapsibleRow.CollapsedProperty),
                    Source = row,
                    Converter = MyBooleanConverter
                });
            }
    
            private static void SetBindingForControlsInCollapsibleRows(Grid grid)
            {
                for (int i = 0; i < grid.RowDefinitions.Count; i++)
                {
                    if (grid.RowDefinitions[i] is CollapsibleRow row)
                    {
                        ElementsInRow(grid, i).ToList().ForEach(uiElement => SyncUIElementWithRow(uiElement, row));
                    }
                }
            }
    
            #endregion
        }
    }
