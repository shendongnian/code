    using Windows.UI.Xaml;
    
    namespace App1
    {
        public sealed partial class MainPage
        {
            public MainPage()
            {
                InitializeComponent();
            }
    
            public static readonly DependencyProperty BlockerZIndexProperty =
                DependencyProperty.Register(
                    nameof(BlockerZIndex),
                    typeof(int),
                    typeof(MainPage),
                    new PropertyMetadata(2));
    
            public int BlockerZIndex
            {
                get => (int)GetValue(BlockerZIndexProperty);
                set => SetValue(BlockerZIndexProperty, value);
            }
    
            private void BlockUnBlockUIButton_OnClick(object sender, RoutedEventArgs e)
            {
                BlockerZIndex = BlockerZIndex == 1 ? 2 : 1;
            }
        }
    }
