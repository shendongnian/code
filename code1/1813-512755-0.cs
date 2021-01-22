    public class Widget {
        public string Name = string.Empty;
        public int Size = 0;
        public Widget(string name, int size) {
        this.Name = name;
        this.Size = size;
    }
    }
    public class WidgetNameSorter : IComparer<Widget> {
        public int Compare(Widget x, Widget y) {
            return x.Name.CompareTo(y.Name);
    }
    }
    public class WidgetSizeSorter : IComparer<Widget> {
        public int Compare(Widget x, Widget y) {
        return x.Size.CompareTo(y.Size);
    }
    }
