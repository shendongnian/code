        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            int numberOfButtons = 3;
            for (int i = 0; i < numberOfButtons; i++)
            {
                var foo = new Foo
                {
                    Image = new BitmapImage(new Uri("ms-appx:///Assets/Square44x44Logo.scale-200.png")),
                    Title = "title" + i,
                    SubTitle = i.ToString()
                };
                Button btn = new Button();
                Style style = Application.Current.Resources["CustomButtonLarge"] as Style;
                btn.Style = style;
                btn.DataContext = foo;
                StackAlbums.Children.Add(btn);
            }
        }
