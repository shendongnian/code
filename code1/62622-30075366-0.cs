        public static IEnumerable<T> FindLogicalChildren<T>(DependencyObject obj) where T : DependencyObject
        {
            if (obj != null) {
                if (obj is T)
                    yield return obj as T;
                foreach (DependencyObject child in LogicalTreeHelper.GetChildren(obj).OfType<DependencyObject>()) 
                    foreach (T c in FindLogicalChildren<T>(child)) 
                        yield return c;
            }
        }
