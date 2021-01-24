    catch (AggregateException ex)
    {
        ex.Handle(x =>
        {
            if (x is UnauthorizedAccessException)
            {
                //the exception you interested
			    throw x;           
            }
            // Other exceptions will not be handled here.
            //some action i.e log
            return false;
        });
    }
