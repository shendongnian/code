    List<string> quotelist=File.ReadAllLines(filename).ToList();
    string firstItem= quotelist[0];
    quotelist.RemoveAt(0);
    File.WriteAllLines(filename, quotelist.ToArray());
    return firstItem;
