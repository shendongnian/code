    from txboxItems in AssetTransferItems
    from user in Memberships
        .Where(u => u.UserId == txboxItems.UserAdded).DefaultIfEmpty()
    from userReceived in Memberships
        .Where(u => u.UserId == txboxItems.UserReceived).DefaultIfEmpty()
    select new
    {
         Description = txboxItems.Description.ToString(),
         DateAdded = (DateTime?) txboxItems.DateAdded.Value,
         UserAdded = user?.Username,
         DateReceived = (DateTime?) txboxItems.DateReceived.Value,
         UserReceived = userReceived?.Username
    }
