    static IEnumerator<Bar> GetDerived()
    {
        using (IEnumerator<Foo> e = GetBase())
        {
            while (e.MoveNext())
            {
                // or use "as" and only return valid data
                yield return (Bar)e.Current;
            }
        }
    }
