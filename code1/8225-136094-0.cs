    catch (Exception ex)
    {
       if (ex.GetType() == typeof(System.FormatException) || 
           ex.GetType() == typeof(System.OverflowException)
       {
           WebId = Guid.Empty;
       }
    }
