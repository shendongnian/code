    using Windows.UI.Xaml.Input;
    
    namespace App1
    {
        public sealed partial class MainPage
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
    
            public void Textwriting_Tapped(object sender, TappedRoutedEventArgs e)
            {
               UIHelper.CreateRemovableTextBoxToCanvas(TextCanvas);
            }
        }
    }
