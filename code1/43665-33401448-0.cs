    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    public static class ParentContentPresenter
    {
        public static readonly System.Windows.DependencyProperty HorizontalAlignmentProperty = System.Windows.DependencyProperty.RegisterAttached(
            "HorizontalAlignment",
            typeof(HorizontalAlignment),
            typeof(ParentContentPresenter),
            new PropertyMetadata(default(HorizontalAlignment), OnHorizontalAlignmentChanged));
        public static void SetHorizontalAlignment(this UIElement element, HorizontalAlignment value)
        {
            element.SetValue(HorizontalAlignmentProperty, value);
        }
        [AttachedPropertyBrowsableForChildren(IncludeDescendants = false)]
        [AttachedPropertyBrowsableForType(typeof(UIElement))]
        public static HorizontalAlignment GetHorizontalAlignment(this UIElement element)
        {
            return (HorizontalAlignment)element.GetValue(HorizontalAlignmentProperty);
        }
        private static void OnHorizontalAlignmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var presenter = d.Parents().OfType<ContentPresenter>().FirstOrDefault();
            if (presenter != null)
            {
                presenter.HorizontalAlignment = (HorizontalAlignment) e.NewValue;
            }
        }
        private static IEnumerable<DependencyObject> Parents(this DependencyObject child)
        {
            var parent = VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                yield return parent;
                child = parent;
                parent = VisualTreeHelper.GetParent(child);
            }
        }
    }
