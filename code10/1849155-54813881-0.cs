    public class CustomFlipView : FlipView
    {
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            SelectionChanged += (s,e) => UpdateNavigationButtonsVisibility();
            Button prev = GetTemplateChild("MyPreviousButtonHorizontal") as Button;
            prev.Click += OnBack;
            prev.Visibility = Visibility.Collapsed;
            Button next = GetTemplateChild("MyNextButtonHorizontal") as Button;
            next.Click += OnNext;
            next.Visibility = Visibility.Collapsed;
        }
        private void OnBack(object sender, RoutedEventArgs e)
        {
            if (Items.Any())
            {
                SelectedIndex--;
                UpdateNavigationButtonsVisibility();
            }
        }
        private void OnNext(object sender, RoutedEventArgs e)
        {
            if (Items.Any())
            {
                SelectedIndex++;
                UpdateNavigationButtonsVisibility();
            }
        }
        private void UpdateNavigationButtonsVisibility()
        {
            Button prev = GetTemplateChild("MyPreviousButtonHorizontal") as Button;
            Button next = GetTemplateChild("MyNextButtonHorizontal") as Button;
            if (SelectedIndex < 1)
                prev.Visibility = Visibility.Collapsed;
            if (SelectedIndex == Items.Count - 1)
                next.Visibility = Visibility.Collapsed;
            if (Items.Count > 1 && SelectedIndex != Items.Count - 1)
                next.Visibility = Visibility.Visible;
            if (Items.Count > 1 && SelectedIndex > 0)
                prev.Visibility = Visibility.Visible;
        }
    }
