        if (container.CanResolve<T> == true)
        {
            try
            {
                return container.Resolve<T>;
            }
            catch (Exception e)
            {
                // do something else
            }
        }
   
