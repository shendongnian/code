    public static DependencyProperty HostProperty = DependencyProperty.Register("Host", typeof(PlayerBase), typeof(MediaPlayerWpf), new PropertyMetadata(null, OnHostChanged));
    public PlayerBase Host { get => (PlayerBase)base.GetValue(HostProperty); set => base.SetValue(HostProperty, value); }
    private static void OnHostChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
    	MediaPlayerWpf P = d as MediaPlayerWpf;
    	if (e.OldValue != null)
    		P.HostGrid.Children.Remove(e.OldValue as PlayerBase);
    	if (e.NewValue != null) {
    		P.HostGrid.Children.Add(e.NewValue as PlayerBase);
    		P.UI.PlayerHost = e.NewValue as PlayerBase;
    	}
    }
