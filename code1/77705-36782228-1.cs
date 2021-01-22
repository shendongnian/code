    public static class StringExm
    {
        public static String ReplaceAll(this String str, KeyValuePair<String, String>[] map)
        {
            if (String.IsNullOrEmpty(str))
                return str;
            StringBuilder result = new StringBuilder(str.Length);
            StringBuilder word = new StringBuilder(str.Length);
            Int32[] indices = new Int32[map.Length];
            for (Int32 characterIndex = 0; characterIndex < str.Length; characterIndex++)
            {
                Char c = str[characterIndex];
                word.Append(c);
                for (var i = 0; i < map.Length; i++)
                {
                    String old = map[i].Key;
                    if (word.Length - 1 != indices[i])
                        continue;
                    if (old.Length == word.Length && old[word.Length - 1] == c)
                    {
                        indices[i] = -old.Length;
                        continue;
                    }
                    if (old.Length > word.Length && old[word.Length - 1] == c)
                    {
                        indices[i]++;
                        continue;
                    }
                    indices[i] = 0;
                }
                Int32 length = 0, index = -1;
                Boolean exists = false;
                for (int i = 0; i < indices.Length; i++)
                {
                    if (indices[i] > 0)
                    {
                        exists = true;
                        break;
                    }
                    if (-indices[i] > length)
                    {
                        length = -indices[i];
                        index = i;
                    }
                }
                if (exists)
                    continue;
                if (index >= 0)
                {
                    String value = map[index].Value;
                    word.Remove(0, length);
                    result.Append(value);
                    if (word.Length > 0)
                    {
                        characterIndex -= word.Length;
                        word.Length = 0;
                    }
                }
                result.Append(word);
                word.Length = 0;
                for (int i = 0; i < indices.Length; i++)
                    indices[i] = 0;
            }
            if (word.Length > 0)
                result.Append(word);
            return result.ToString();
        }
    }
