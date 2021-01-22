    using (IEnumerator<Foo> iterator = source.GetEnumerator())
    {
        Foo element;
        while (iterator.MoveNext())
        {
            element = iterator.Current;
            // Body
        }
    }
