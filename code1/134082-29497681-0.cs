    public static void InvokeIfRequired<T>(this T obj, Action<T> action)
        where T : ISynchronizeInvoke
    {
        if (obj.InvokeRequired)
        {
            obj.Invoke(new Action(() => action(obj)), new object[] { });
        }
        else
        {
            action(obj);
        }
    } 
