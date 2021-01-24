    private bool DeleteModel(Order order)
    {
        try
        {
            _context.Database.ExecuteSqlCommand($"DELETE Order WHERE Id={order.Id}");
            _context.SaveChanges();
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
    public bool SaveOrder(Order order)
    {
        try
        {
            //Delete Model First
            if(DeleteModel(order))
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        catch(Exception ex)
        {
            return false;
        }
    }
