    var haystacks = new List<string[]>();
    haystacks.Add(new string[] { "abc", "def", "ghi" });
    haystacks.Add(new string[] { "abc", "ghi" });
    haystacks.Add(new string[] { "def" });
    string needle = "def";
    
    var haystacksWithNeedle = haystacks
        .Where(haystack => Array.IndexOf(haystack, needle) != -1);
