        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null && item is AuctionItem)
            {
                AuctionItem auctionItem = item as AuctionItem;
                switch (auctionItem.SpecialFeatures)
                {
                    case SpecialFeatures.None:
                        return 
                            ((FrameworkElement)container).FindResource("AuctionItem_None") 
                            as DataTemplate;
                    case SpecialFeatures.Color:
                        return 
                            ((FrameworkElement)container).FindResource("AuctionItem_Color") 
                            as DataTemplate;
                }
            }
            return null;
        }
