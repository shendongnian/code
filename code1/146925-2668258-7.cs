    public void Vegetables_Opened(object sender, RoutedEventArgs e)
    {
      var menu = (ContextMenu)sender;
      var data = (MyDataClass)menu.DataContext
      var oldCarrots = (
        from item in menu.Items
        where (string)item.Header=="Carrots"
        select item
      ).FirstOrDefault();
      if(oldCarrots!=null)
        menu.Items.Remove(oldCarrots);
      if(ComplexCalculationOnDataItem(data) && UnrelatedCondition())
        menu.Items.Add(new MenuItem { Header = "Carrots" });
    }
