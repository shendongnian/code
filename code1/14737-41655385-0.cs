    char c = '\n';                              
    Debug.Print($"{c & 15}");                   // 10
    Debug.Print($"{c ^ 48}");                   // 58
    Debug.Print($"{c - 48}");                   // -38
    Debug.Print($"{(uint)c - 48}");             // 4294967258
    Debug.Print($"{char.GetNumericValue(c)}");  // -1 
