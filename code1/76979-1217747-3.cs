    public IList<T> GreaterThan<T>(T t)
    {
        IList<T> list = GetList<T>();
        var items = () => {
            foreach (var item in list)
                if (fun.Invoke(item))
                    yield return item; // This is not allowed by C#
        }
        return items.ToList();
    }
