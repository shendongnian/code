    class ItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if(item is MenuItem mItem)
            {
                if(mItem.Items.Count > 0)
                {
                    return App.Current.Resources["MenuItemWithChildren"] as Style;
                }
                else
                {
                    return App.Current.Resources["MenuItemWithoutChildren"] as Style;
                }
            }
            return base.SelectStyle(item, container);
        }
    }
