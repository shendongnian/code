     Button button;
        private void AddItemsToUi(MainPageViewModel vm)
        {
            foreach (var item in vm.Items)
            {
                button = new Button
                {
                    Text = item,
                    TextColor = Color.White
                };                
                button.Clicked += Button_Clicked;
            }
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = (sender as Button);
            button.BackgroundColor = Color.Red;
        }
        protected override void OnDisappearing()
        {
            button.Clicked -= Button_Clicked;
            base.OnDisappearing();
        }
