        if (source == null)
        {
            throw Error.ArgumentNull(nameof(source));
        }
        if (source is IList<TSource> list)
        {
            switch (list.Count)
            {
                case 0:
                    throw Error.NoElements();
                case 1:
                    return list[0];
            }
        }
        else
        {
            using (IEnumerator<TSource> e = source.GetEnumerator())
            {
                if (!e.MoveNext())
                {
                    throw Error.NoElements();
                }
                TSource result = e.Current;
                if (!e.MoveNext())
                {
                    return result;
                }
            }
        }
        throw Error.MoreThanOneElement();
    }
