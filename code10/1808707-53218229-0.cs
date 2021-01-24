    var result = new List<string>(m+n);
    int i = 0, j = 0;
    while (i < l1.Count && j < l2.Count) {
        if (l1[i] < l2[j]) { // Of course you have to change this part, the idea is to compare both items
            result.Add(l1[i++]);
        } else {
            result.Add(l2[j++]);
        }
    }
    while(i < l1.Count) { result.Add(l1[i++]); }
    while(j < l2.Count) { result.Add(l2[j++]); }
