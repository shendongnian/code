    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    
    namespace Question_Answer_WPF_App
    {
        public partial class FlyoutControl : ContentControl
        {
            public FlyoutControl() => InitializeComponent();
    
            private void OpenFlyout()
            {
                var openStoryboard = Resources["OpenStoryboard"] as Storyboard;
                var openInnerContentStoryboard = Resources["OpenInnerContentStoryboard"] as Storyboard;
    
                openStoryboard.Begin();
                openInnerContentStoryboard.Begin(this, Template);
            }
    
            private void CloseFlyout()
            {
                var closeStoryboard = Resources["CloseStoryboard"] as Storyboard;
                var closeInnerContentStoryboard = Resources["CloseInnerContentStoryboard"] as Storyboard;     
                
                closeStoryboard.Begin();
                closeInnerContentStoryboard.Begin(this, Template);
            }
    
            public bool IsOpen
            {
                get { return (bool)GetValue(IsOpenProperty); }
                set { SetValue(IsOpenProperty, value); }
            }
    
            public static readonly DependencyProperty IsOpenProperty =
                DependencyProperty.Register(nameof(IsOpen),
                                            typeof(bool),
                                            typeof(FlyoutControl),
                                            new PropertyMetadata(false,
                                            new PropertyChangedCallback((s, e) =>
                                            {
                                                if (s is FlyoutControl flyoutControl && e.NewValue is bool boolean)
                                                {
                                                    if (boolean)
                                                    {
                                                        flyoutControl.OpenFlyout();
                                                    }
                                                    else
                                                    {
                                                        flyoutControl.CloseFlyout();
                                                    }
                                                }
                                            })));
    
            //Closes Flyout
            private void BackgroundButtonClick(object sender, RoutedEventArgs e) => IsOpen = false;
    
            //Disables clicks from within inner content from explicitly closing Flyout.
            private void InnerContentButtonClick(object sender, RoutedEventArgs e) => e.Handled = true;
        }
    }
