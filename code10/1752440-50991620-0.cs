     Statistics.ScrollPositionData GetScrollPosition()
        {
            try
            {
                if (VisualTreeHelper.GetChildrenCount(dg_timing) > 0)
                {
                    var border = VisualTreeHelper.GetChild(dg_timing, 0) as Decorator;
                    if (border != null)
                    {
                        var scroll = border.Child as ScrollViewer;
                        if (scroll != null)
                        {
                            return new Statistics.ScrollPositionData()
                            {
                                offset = (int)scroll.VerticalOffset,
                                rowId =  (((DataRowView)dg_timing.Items[(int)scroll.VerticalOffset]).Row.ItemArray[((Statistics)DataContext).GetColumnOrder("Timeline")] as TextBlock).Text
                            };
                        }
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
