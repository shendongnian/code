    public static String LongestConsec(string[] strarr, int k)
    {
        string final = String.Join("", 
            strarr.Distinct()                       // Remove Duplicates
                  .OrderByDescending(s => s.Length) // Order by Length
                  .Take(k)                          // Take from List
        );
        return final;
    } 
