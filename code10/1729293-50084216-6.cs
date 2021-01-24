    public void AddItem(Item item, int amount = 1)
    {
        var slot = inv.FirstOrDefault(s => s?.Item == item && s.Quantity < item.maxstack);
        if (slot != null)
        {
            slot.Quantity++;
        }
        else
        {
            slot = inv.FirstOrDefault(s => s == null);
            if (slot != null)
            {
                slot.Item = item;
                slot.Quantity = 1;
            }
        }
    }
