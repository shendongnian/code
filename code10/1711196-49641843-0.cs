    public class PDTPopup : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PDTPopup(ContentView view)
        {
            Frame frame = new Frame
            {
                CornerRadius = 8,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Content = view
            };
            this.Content = new Xamarin.Forms.StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromHex("#00000000"),
                Padding = new Thickness(20, 0, 20, 0),
                Children =
                {
                    frame
                }
            };
        }
    }
