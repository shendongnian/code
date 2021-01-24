    string s = "1BC34D";
    char[] characters = s.ToCharArray();
    for (int i = 0; i < characters.Length; i++)
     {
       if (Char.IsNumber(characters[0]))
        {
            var index = characters[0];
            var stringAlbhabet = albhabets[index];
        }
      else
        {
            var digitCharacter = albhabets.IndexOf(characters[0]);
        }
    }
