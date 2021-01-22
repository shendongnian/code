    public static void QueueTwoParameterWorkItem<T1, T2>(T1 value1, T2 value2, workDelegate<T1,T2> work)
    {
        try
        {
            T1 param1 = value1;
            T2 param2 = value2;
            ThreadPool.QueueUserWorkItem(
                (o) =>
                {
                    work(param1, param2);
                });
        }
        catch (Exception ex)
        {
            //exception logic
        }
    }
