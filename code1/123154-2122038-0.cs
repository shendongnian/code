    public string SortByDateModified(List<CartItem> items) 
    { 
        items.Sort(delegate(CartItem itemA, CarItem itemB) 
        { 
            return itemA.DateModified.CompareTo(itemB.DateModified); 
        }); 
    } 
