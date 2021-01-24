    UIElement _uIElement;
    
    void AnimateScrollCompositionAPI()
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
    
    			var visual = ElementCompositionPreview.GetElementVisual(_uIElement);
    			ElementCompositionPreview.SetIsTranslationEnabled(_uIElement, true);
    			var easing = visual.Compositor.CreateLinearEasingFunction();
    			var anim = visual.Compositor.CreateVector3KeyFrameAnimation();
    			anim.Duration = duration;
    			anim.InsertKeyFrame(1f, new Vector3(0, (int)newOffsetY, 0), easing);
    			visual.StartAnimation("Translation", anim);
    		}
    		else
    		{
    			_sliderVertical.Value = _scrollViewer.VerticalOffset;
    		}
    	}
    }
