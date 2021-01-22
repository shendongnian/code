    IEnumerable<char> query2 = "Not what you might expect";
    Char vowel = 'a'; query2 = query2.Where(c => c != vowel);
    vowel = 'e'; query2 = query2.Where(c => c != vowel);
    vowel = 'i'; query2 = query2.Where(c => c != vowel);
    vowel = 'o'; query2 = query2.Where(c => c != vowel);
    vowel = 'u'; query2 = query2.Where(c => c != vowel);
