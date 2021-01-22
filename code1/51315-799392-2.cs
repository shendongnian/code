    public void SetDiscountAmount(decimal discountAmount)
    {
       DiscountOrderItem item = _Items
          .Where(x => x is DiscountOrderItem)
          .SingleOrDefault();
       if (item == null)
       {
           item = new DiscountOrderItem();
           _Items.Add(item);
       }
       item.DiscountAmount = discountAmount;
    }
