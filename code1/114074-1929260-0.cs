    class HeroControl
    {
      bool IsSelected {get;set;}
    
      MouseEnter()
      {
        if (!IsSelected) 
        {
          SetGlow(true);
        }
      }
    
      MouseLeave()
      {
        if (!IsSelected)
        {
          SetGlow(false);
        }
      }
    
      MouseDown()
      {
        IsSelected = true;
        // May be event invocation or method call or any other way.
        NotifySelectedHeroChanged(this); 
      }
    }
    class HeroesContainer
    {
      List Heroes;
      
      OnCurrentHeroChanged(newHero, oldHero)
      {
       oldHero.IsSelected = false;
       // update new hero if needed.
      }
    }
