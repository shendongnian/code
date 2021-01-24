    private void Grid_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        var element = imageBackdrop;
        var visual = ElementCompositionPreview.GetElementVisual(element);
        var compositor = visual.Compositor;
    
        var effect = new GaussianBlurEffect()
        {
            Name = "Blur",
            Source = new CompositionEffectSourceParameter("EffectSource"),
            BlurAmount = 50f,
            BorderMode = EffectBorderMode.Soft,
        };
    
        var blurEffectFactory = compositor.CreateEffectFactory(effect, new[] { effect.Name + "." + nameof(effect.BlurAmount) });
        var brush = blurEffectFactory.CreateBrush();
        var destinationBrush = compositor.CreateBackdropBrush();
        brush.SetSourceParameter("EffectSource", destinationBrush);
    
        var sprite = compositor.CreateSpriteVisual();
        sprite.Size = new Vector2((float)(element.RenderSize.Width), (float)(element.RenderSize.Height));
        sprite.Brush = brush;
        ElementCompositionPreview.SetElementChildVisual(element, sprite);
        imageBackdropContainer.Opacity = 1;
    }
    
    private void Grid_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
    {
        imageBackdropContainer.Opacity = 0;
    }
