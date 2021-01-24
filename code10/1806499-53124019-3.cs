    private T Execute<T>(Func<T> action)
    {
        if (someCondition)
        {
            try
            {
                return action();
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
