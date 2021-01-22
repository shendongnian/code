    IEnumerator<string> names = GetFileNames().GetEnumerator();
    names.MoveNext();
    string name1 = names.Current;
    names.MoveNext();
    string name2 = names.Current;
    // etc, etc.
