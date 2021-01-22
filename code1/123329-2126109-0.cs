    Hashtable nameHash = new Hashtable();
    foreach (string name in arrName) {
        if (!nameHash.ContainsKey(name)) {
            nameHash.Add(name, 1);
        }
        else {
            int num = nameHash[name];
            nameHash.Add(name, num + 1);
        }
    }
   
