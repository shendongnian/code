    string word1 = "AN";
    string word2 = "ANN";
    //get all the characters in both strings
    var group = string.Concat(word1, word2)
        //remove duplicates
        .Distinct()
        //count the times each character appears in word1 and word 2, find the
        //difference, and create a new string that repeat the character difference times
        .Select(i => new string(i, Math.Abs(
            word1.Where(j => j == i).Count() - 
            word2.Where(j => j == i).Count())))
        //join the strings
        .Aggregate((i, j) => { return i + j; });
