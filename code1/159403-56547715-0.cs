    public static class ListViewExtensions {
        public static int GetTopItemIndex(this ListView lv) {
            if (lv.Items.Count == 0) {
                return -1;
            }
            VirtualizingStackPanel vsp = lv.GetVisualChild<VirtualizingStackPanel>();
            if (vsp == null) {
                return -1;
            }
            return (int) vsp.VerticalOffset;
        }
        public static void ScrollToTopItem(this ListView lv, object item) {
            ScrollViewer sv = lv.GetVisualChild<ScrollViewer>();
            sv.ScrollToBottom();
            lv.ScrollIntoView(item);
        }
    }
