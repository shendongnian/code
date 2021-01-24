    public TimeTableView(ViewModel model)
    {
        foreach (CardViewModel cardModel in CardViewData)
        {
            CardView view = new CardView(cardModel);
            Container.Children.Add(view);
        }
    }
