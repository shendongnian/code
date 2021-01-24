    var dict = new Dictionary<string, List<string>>();
    for (int i = 0; i < sourse.Length; i += 2) {
        for (int j = 0; j < target.Length; j += 2) {
            if (sourse[i] == target[j]) {
                Add(dict, sourse[i + 1], target[j + 1]);
                break;
            }
        }
    }
