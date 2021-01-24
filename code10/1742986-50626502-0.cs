    List<string> keys = new List<string>();
    keys.Add("Word1"); // ... and so on
    // IMPORTANT: algorithm works only when we are sure that one key cannot be
    //            included in another key with higher index. Also, uniqueness is
    //            guaranteed by construction, although the routine would work
    //            duplicate key...!
    keys = keys.OrderByDescending(x => x.Length).ThenBy(x => x).ToList<string>();
    // first loop: replace with some UNIQUE key hash in text
    foreach(string key in keys) {
      txt.Replace(key, string.Format("!#someUniqueKeyNotInKeysAndNotInTXT_{0}_#!", keys.IndexOf(key)));
    }
    // second loop: replace UNIQUE key hash with corresponding values...
    foreach(string key in keys) {
      txt.Replace(string.Format("!#someUniqueKeyNotInKeysAndNotInTXT_{0}_#!", keys.IndexOf(key)), string.Format("{0}{1}{2}", preStr, key, postStr));
    }
