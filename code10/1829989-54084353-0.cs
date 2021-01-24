    Compositor _compositor = Window.Current.Compositor;
    SpringVector3NaturalMotionAnimation _springAnimation;
    
    private void Btn_PointerEntered(object sender, PointerRoutedEventArgs e)
    {
        CreateOrUpdateSpringAnimation(1.5f);
        (sender as UIElement).CenterPoint = new Vector3((float)(Btn.ActualWidth / 2.0), (float)(Btn.ActualHeight / 2.0), 1f);
        (sender as UIElement).StartAnimation(_springAnimation);
    
    }
    
    private void Btn_PointerExited(object sender, PointerRoutedEventArgs e)
    {
        CreateOrUpdateSpringAnimation(1.0f);
        (sender as UIElement).CenterPoint = new Vector3((float)(Btn.ActualWidth / 2.0), (float)(Btn.ActualHeight / 2.0), 1f);
        (sender as UIElement).StartAnimation(_springAnimation);
    
    
    }
    private void CreateOrUpdateSpringAnimation(float finalValue)
    {
        if (_springAnimation == null)
        {
            _springAnimation = _compositor.CreateSpringVector3Animation();
            _springAnimation.Target = "Scale";
    
        }
    
        _springAnimation.FinalValue = new Vector3(finalValue);
    }
