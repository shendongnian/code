        private void HideHeader()
        {
            var myWindow = new RadWindow();
            var header = FindVisualChildren<Grid>(myWindow).FirstOrDefault(elem => elem.Name == "Header");
            if (header != null)
                header.Visibility = Visibility.Collapsed;
        }
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject parent)
            where T : DependencyObject
        {
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T children)
                    yield return children;
                foreach (var other in FindVisualChildren<T>(child))
                    yield return other;
            }
        }
