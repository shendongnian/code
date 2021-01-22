        public bool PlaySounds
        {
            get { return (bool)GetValue(PlaySoundsProperty); }
            set { SetValue(PlaySoundsProperty, value); }
        }
        public static readonly DependencyProperty PlaySoundsProperty =
            DependencyProperty.Register("PlaySounds", typeof(bool), typeof(Options),
            new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnPlaySoundsChanged)));
        private static void OnPlaySoundsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            Properties.Settings.Default.PlaySounds = (bool)args.NewValue;
            Properties.Settings.Default.Save();
        }
