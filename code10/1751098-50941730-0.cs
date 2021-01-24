    private void Frame_Loaded(object sender, RoutedEventArgs e)
    {
        ((UIElement)sender).AddHandler(Buttion.ClickEvent, (RoutedEventHandler)((e, e1) =>
        {
            Button btn = (Button)e1.OriginalSource;
            if (btn.Name == "same kind of id")
            {
                // handle the event.
            }
        }));
    }
