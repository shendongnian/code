    using (IEnumerator<Foo> iterator = GetFoos().GetEnumerator())
    {
        while (iterator.MoveNext())
        {
            Foo f = iterator.Current;
            // Do stuff
        }
    }
