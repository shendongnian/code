    double offset = 0.0;
    private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
    {
      offset = GetScrollViewerOffsetProportion(svMain) ;
      svMain.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
    }
                
    public static void ScrollToProportion(ScrollViewer scrollViewer, double scrollViewerOffsetProportion)
    {
      if (scrollViewer == null) return;
      var scrollViewerHorizontalOffset = scrollViewerOffsetProportion * scrollViewer.ScrollableWidth;
      var scrollViewerVerticalOffset = scrollViewerOffsetProportion * scrollViewer.ScrollableHeight;
      scrollViewer.ChangeView(scrollViewerHorizontalOffset, scrollViewerVerticalOffset, null);
    }
    public static double GetScrollViewerOffsetProportion(ScrollViewer scrollViewer)
    {
      if (scrollViewer == null) return 0;
      
      var horizontalOffsetProportion = (scrollViewer.ScrollableWidth == 0) ? 0 : (scrollViewer.HorizontalOffset / scrollViewer.ScrollableWidth);
      var verticalOffsetProportion = (scrollViewer.ScrollableHeight == 0) ? 0 : (scrollViewer.VerticalOffset / scrollViewer.ScrollableHeight);
      
      var scrollViewerOffsetProportion = Math.Max(horizontalOffsetProportion, verticalOffsetProportion);
      return scrollViewerOffsetProportion;
    }
    private void svMain_ViewChanging(object sender, ScrollViewerViewChangingEventArgs e)
    {
    	if (svMain.HorizontalScrollBarVisibility == ScrollBarVisibility.Hidden)
        {
            ScrollToProportion(svMain, offset);
        }
    }
