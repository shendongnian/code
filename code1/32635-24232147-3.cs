        public static readonly DependencyProperty ClipboardStringDP =
            DependencyProperty.Register("ClipboardString",
                                        typeof(string),
                                        typeof(MainWindow),
                                        new UIPropertyMetadata(string.Empty));
        public string ClipboardString
        {
            get { return (string)this.GetValue(ClipboardStringDP); }
            set { this.SetValue(ClipboardStringDP, value); }
        }
