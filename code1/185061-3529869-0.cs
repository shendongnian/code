    public static class GridExtensions {
        public static IEnumerable<FrameworkElement> GetXYChild(this Grid instance, int x, int y) {
            if (null == instance) {
                throw new ArgumentNullException("instance");
            }
            List<FrameworkElement> list = new List<FrameworkElement>();            
            foreach (FrameworkElement fe in instance.Children) {
                if (Grid.GetRow(fe) == y && Grid.GetColumn(fe) == x) {
                    list.Add(fe);
                }
            }
            return list;
        }
    }
