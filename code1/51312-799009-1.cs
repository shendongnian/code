    public IList<OrderItem> Fees
    {
       get
       {
          return _items.Find(i=>i.ItemType==ItemType.Fee);
       }
    }
