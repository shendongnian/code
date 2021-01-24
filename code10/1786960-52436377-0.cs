     var pricetabs = (((this.Price.Content as Grid).Children[0] as PriceTab).DataContext as ViewModels.PriceTabControl).Tabs;
     String res = "";
     foreach (ViewModels.PriceViewModel v in pricetabs)
     {
         res += v.PriceLevel.ToString()
     }
