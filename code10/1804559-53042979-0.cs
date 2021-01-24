    using (IEnumerator<TSource> e = source.GetEnumerator())
    {
        while (e.MoveNext())
        {
            TSource result = e.Current;
            if (predicate(result))
            {
                while (e.MoveNext())
                {
                    if (predicate(e.Current))
                    {
                        throw Error.MoreThanOneMatch();
                    }
                }
                return result;
            }
        }
    }
