    String s1 = "aeiou";
    String s2 = "This is a test string which could be any text";
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < s2.Length; i++)
    {
        // Check if current char is not contained in s1,
        // then add it to sb
        if (!s1.Contains(s2[i]))
        {
            sb.Append(s2[i]);
        }
    }
    string result = sb.ToString();
