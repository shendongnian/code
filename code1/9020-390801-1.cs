    public static bool DoStartsWith(this string s, string t) {
        if (s.Length >= t.Length) {
            for (int index = 0; index < t.Length; index++) {
                if (s[index] != t[index]) {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
