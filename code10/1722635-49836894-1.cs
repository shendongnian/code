        bool isEscape;
        public SampleDialog()
        {
            isEscape = true;
            this.InitializeComponent();
            this.Closing += SampleDialog_Closing;
        }
        private void SampleDialog_Closing(ContentDialog sender, ContentDialogClosingEventArgs args)
        {
            if (isEscape)
                args.Cancel = true;
        }
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Title = "Primary button clicked";
        }
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            isEscape = false;
            this.Hide();
        }
