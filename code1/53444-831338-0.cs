    Dictionary<string, int> sectionIndex = new Dictionary<string, int>();
    List<string> headers = new List<string>(); // fill these with readline
    foreach(string header in headers) {
        var s = header.Split(new[]{' '});
        sectionIndex.Add(s[0], Int32.Parse(s[1]));
    }
