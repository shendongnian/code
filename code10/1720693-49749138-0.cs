    public static void CompositionAnimationBlur(UIElement element, int durationMilliseconds)
    {
        var visual = ElementCompositionPreview.GetElementVisual(element);          
        var compositor = visual.Compositor;
        var AnimationGroup = compositor.CreateAnimationGroup();
    
        var effect = new GaussianBlurEffect()
        {
            Name = "Blur",
            Source = new CompositionEffectSourceParameter("EffectSource"),
            BlurAmount = 0f,
            BorderMode = EffectBorderMode.Hard,
        };
    
        var blurEffectFactory = compositor.CreateEffectFactory(effect, new[] { effect.Name + "." + nameof(effect.BlurAmount) });
        var brush = blurEffectFactory.CreateBrush();
        var destinationBrush = compositor.CreateBackdropBrush();
        brush.SetSourceParameter("EffectSource", destinationBrush);
    
        var sprite = compositor.CreateSpriteVisual();
        sprite.Size = new Vector2((float)(element.RenderSize.Width), (float)(element.RenderSize.Height));
        sprite.Brush = brush;
    
        var anim = compositor.CreateScalarKeyFrameAnimation();
        anim.InsertKeyFrame(0.0f, 0f);
        anim.InsertKeyFrame(1.0f, 50f);
        anim.Target = "Blur.BlurAmount";
        anim.Duration = TimeSpan.FromMilliseconds(durationMilliseconds);
        ElementCompositionPreview.SetElementChildVisual(element, sprite);
        AnimationGroup.Add(anim);
    
        sprite.Brush.Properties.StartAnimationGroup(AnimationGroup);
    }
