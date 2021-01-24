    var userToChange;
    using (var context = new ShopContext())
    {
        userToChange = context.UsersTable.Where((u) => u.Id == userId).FirstOrDefault();
    }
    using (var context = new ShopContext())
    {
        if (userToChange != null)
        {
            if (isUserActive)
            {
                userToChange.IsActive = false;
                context.SaveChanges();
            }
            else
            {
                userToChange.IsActive = true;
                context.SaveChanges();
            }
            return true;
        }
        return false;
    }
