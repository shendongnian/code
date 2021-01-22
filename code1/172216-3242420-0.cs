    public static Boolean AddOrder(order o, int userId)
            {
                try
                {
                    user u = db.users.Single(us => us.userId == userId);
                    u.orders.Add(o);                
                    
                    db.SubmitChanges();
    
                    return true;
                }
                catch
                {
                    return false;
                }
            }
