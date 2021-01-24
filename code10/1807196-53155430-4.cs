    Today today = new Today();
    foreach(History history in a) {
        today.Views += history.Views;
        today.Clicks += history.Clicks;
        today.Points += history.Points;
    }
