    private void RenderMenu()
    {
        NavMain.MenuItems.Add(new NavigationViewItemSeparator());
    
        foreach (TarotSuit suit in deck.Suits)
        {
            // make a nav menu item for the suit
            MUXC.NavigationViewItem newMenu = new MUXC.NavigationViewItem();
            newMenu.Content = suit.Suit;
            newMenu.Icon = new SymbolIcon(Symbol.OutlineStar);
    
            NavMain.MenuItems.Add(newMenu);
        }
    }
