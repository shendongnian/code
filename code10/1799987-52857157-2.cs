    List<string> vars = new List<string>();
    string val = string.Empty;
    for (int i = 0; i < var1.Length; i++) {
        if (i % 10 == 0) {
            vars.Add(val);
            val = string.Empty;
        }
        val += var1[i];
    }
