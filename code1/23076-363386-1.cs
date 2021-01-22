    // Only on non-generic collections,
    // Or generic collections that you know implement nothing in Dispose()
    IEnumerator en = collection.GetEnumerator();
    en.MoveNext();
    return en.Current;
