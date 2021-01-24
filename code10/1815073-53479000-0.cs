    int current = Interlocked.Increment(ref state.OrderStatus);
    try
    {
        if (current > 5)
        {
            Log.Debug("INVALID - state.OrderStatus: " + state.OrderStatus.ToString() + ", ID: " + id.ToString());
            return await Task.FromResult("INVALID");
        }
        else
        {
            Log.Debug("state.OrderStatus: " + state.OrderStatus.ToString() + ", ID: " + id.ToString());
            result = DoGetOrder(id);
        }
    }
    finally
    {
        Interlocked.Decrement(ref state.OrderStatus);
    }
