        private void RemoveDiscontinuedItems()
        {
            RemoveItems(item => item.ItemIsOnSite);
        }
        private void RemovePriceChangedItems()
        {
            RemoveItems(item => PricingOptionIsValid(item));
        }
        private void RemoveAll()
        {
            RemoveItems(item => item.ItemIsOnSite || PricingOptionIsValid(item));
        }
        private void RemoveItems(Predicate<Item> removeIfTruePredicate)
        {
            itemList.RemoveAll(
                item =>
                {
                    if(removeIfTruePredicate(item))
                    {
                        RemoveItem(item);
                        return true;
                    }
                    return false;
                });
        }
