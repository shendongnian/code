    private void CardClick(object sender, MouseButtonEventArgs e)
    {
        if (numberOfClicks < 2)
        {
            Image card = (Image)sender;
            ImageSource front = (ImageSource)card.Tag;
            card.Source = front;
            if(this.Image1 == null){
               Image1 = card;
            }
            else if(this.Image2 == null){
               Image2 = card;
            }
            numberOfClicks++;
        }
        if (numberOfClicks == 2)
        {
            resetCards(Image1, Image2);
            numberOfClicks = numberOfClicks -2;
        }
    }
