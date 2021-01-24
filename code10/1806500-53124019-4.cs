    private Task<T> ExecuteAsync<T>(Func<Task<T>> action)
    {
        if (someCondition)
        {
            try
            {
                return await action();
            }
            catch (RedisConnectionException)
            {
                //do something
            }
        }
        else
        {
            // do something else
        }
    
        return default(T);
    }
