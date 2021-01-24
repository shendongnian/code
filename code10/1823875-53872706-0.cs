    protected override Size ArrangeOverride(Size finalSize)
        {
            List<UIElement> visibleItems = new List<UIElement>();
            double xColumn1 = 0;
            double xColumn2 = (finalSize.Width / 2) + (WIDTH_COLUMN_SEPERATOR / 2);
            double y = 0;
            double columnWidth = (finalSize.Width - WIDTH_COLUMN_SEPERATOR) / 2;
            for (int i = 0; i < InternalChildren.Count; i++)
            {
                UIElement child = InternalChildren[i];
                if (child.Visibility != Visibility.Collapsed)
                {
                    visibleItems.Add(child);
                }
            }
            for (int i = 0; i < visibleItems.Count; i++)
            {
                if (i >= (visibleItems.Count - 1))
                {
                    visibleItems[i].Arrange(new Rect(xColumn1, y, columnWidth, visibleItems[i].DesiredSize.Height));
                }
                else
                {
                    UIElement leftItem = visibleItems[i];
                    UIElement rightItem = visibleItems[i + 1];
                    double rowHeight = leftItem.DesiredSize.Height > rightItem.DesiredSize.Height ? leftItem.DesiredSize.Height : rightItem.DesiredSize.Height;
                    leftItem.Arrange(new Rect(xColumn1, y, columnWidth, rowHeight));
                    rightItem.Arrange(new Rect(xColumn2, y, columnWidth, rowHeight));
                    y += rowHeight;
                    i++;
                }
            }
            return finalSize;
        }
