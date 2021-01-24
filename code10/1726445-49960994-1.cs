    using Microsoft.Toolkit.Uwp.UI.Animations;
    
    UIElement _uIElement;
    
    void AnimateScrollUWPToolkit()
    {
    	if (CanScrollVertical())
    	{
    		if (Math.Abs(offsetY) > _threshold)
    		{
    			if ((_scrollViewer.ScrollableHeight / (Math.Abs(offsetY) * _factor)) == double.NaN)
    			{
    				return;
    			}
    
    			var newOffsetY = _scrollViewer.VerticalOffset + (offsetY > 0 ? _scrollViewer.ScrollableHeight : -_scrollViewer.ScrollableHeight);
    			var duration = TimeSpan.FromSeconds(_scrollViewer.ScrollableHeight / (Math.Abs(offsetY) * _factor));
    
    			_uIElement.Offset(0, (float)_scrollViewer.VerticalOffset, 0).Start();
    			_uIElement.Offset(0, (float)newOffsetY, duration.TotalMilliseconds).Start();
    		}
    		else
    		{
    			_sliderVertical.Value = _scrollViewer.VerticalOffset;
    		}
    	}
    } 
