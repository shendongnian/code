        public static IEnumerable<DependencyObject> GetDescendants(this DependencyObject container)
        {
            var stack = new Stack<DependencyObject>();
            stack.Push(container);
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                var count = VisualTreeHelper.GetChildrenCount(item);
                for (int i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(item, i);
                    yield return child;
                    stack.Push(child);
                }
            }
        }
