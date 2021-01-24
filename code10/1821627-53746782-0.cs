    from item in Items
    select new
    {
       Owned = OwnedItems.Any(own => own.UserId == userId && own.ItemId == item.Id),
       Item = new { Id = item.Id, Name = item.Name }
    }
