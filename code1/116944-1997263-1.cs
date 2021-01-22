    foreach (Hero h in HeroesCollection)
    {
       h.IsVisible = h.Faction == selectedFaction 
          ? Visiblity.Visible 
          : Visibility.Collapsed;
    }
