    private bool hasDelay;
    private async void resetCards(Image card1, Image card2)
    {
        this.Image1 = card1;
        this.Image2 = card2;
        hasDelay = true;
        await Task.Delay(2000);
        card1.Source = new BitmapImage(new Uri("/images/back.png", UriKind.Relative));
        card2.Source = new BitmapImage(new Uri("/images/back.png", UriKind.Relative));
        hasDelay = false;
    }
