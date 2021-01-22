    using (IEnumerator enumerator = doc.Masters.GetEnumerator())
    {
        while (enumerator.MoveNext())
        {
            Visio.Master master = (Visio.Master) enumerator.Current;
            // Loop body
        }
    }
