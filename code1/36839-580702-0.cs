    using (IEnumerator<string> iterator = foo.GetEnumerator())
    {
        while (iterator.MoveNext())
        {
            string bar = iterator.Current;
            // etc
        }
    }
