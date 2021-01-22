    if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
    {
      using (var context = new Data.TVShowDataContext())
      {
        var list = from show in context.Shows
                   select show;
        listShow.ItemsSource = list;
      }    
    }
