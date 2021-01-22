    new public System.Collections.IEnumerator GetEnumerator()
    {
        foreach (string value in (List<string>)this) //<-- note the cast
            yield return baseDirectory + value;
    }
