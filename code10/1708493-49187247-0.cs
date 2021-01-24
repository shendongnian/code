        public static readonly DependencyProperty DelayedTextChangedCommandProperty =
            DependencyProperty.Register(
                "DelayedTextChangedCommand",
                typeof(ICommand),
                typeof(DelayedTextBox),
                new PropertyMetadata(0));
