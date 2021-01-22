    foreach (string param in params.Split(';'))
    {
        string[] parts = param.Split('=');
        string key = parts[0].Trim().ToLower();
        string value = parts[1].Trim();
        MyHashTable[key] = value;
    }
