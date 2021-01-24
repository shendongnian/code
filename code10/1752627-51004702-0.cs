    static MediaPlayerWpf() {
        ContentProperty.OverrideMetadata(typeof(MediaPlayerWpf), new FrameworkPropertyMetadata(ContentChanged, CoerceContent));
    }
    public override void OnApplyTemplate() {
        base.OnApplyTemplate();
        UI = TemplateUI;
        UI.PlayerHost = Content as PlayerBase;
    }
    
    private static void ContentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
        MediaPlayerWpf P = d as MediaPlayerWpf;
        if (P.TemplateUI != null)
            P.TemplateUI.PlayerHost = e.NewValue as PlayerBase;
    }
    private static object CoerceContent(DependencyObject d, object baseValue) {
        return baseValue as PlayerBase;
    }
