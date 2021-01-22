    Dictionary<string, int> idStrings = new Dictionary<string, int>();
    int count = hits.Length();
    for (int i = 0; i < count; i++) {
       string idString = hits.Doc(i).Get("id");
       if (!idStrings.ContainsKey(idString)) {
          idStrings.Add(idString, 1);
       }
    }
