    /// <summary>
    /// Return an incremented alphabtical string
    /// </summary>
    /// <param name="letter">The string to be incremented</param>
    /// <returns>the incremented string</returns>
    public static string NextLetter(string letter)
    {
      const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      if (!string.IsNullOrEmpty(letter))
      {
        char lastLetterInString = letter[letter.Length - 1];
        
        // if the last letter in the string is the last letter of the alphabet
        if (alphabet.IndexOf(lastLetterInString) == alphabet.Length - 1) 
        {
            //replace the last letter in the string with the first leter of the alphbat and get the next letter for the rest of the string
            return NextLetter(letter.Substring(0, letter.Length - 1)) + alphabet[0];
        }
        else 
        {
          // replace the last letter in the string with the proceeding letter of the alphabet
          return letter.Remove(letter.Length-1).Insert(letter.Length-1, (alphabet[alphabet.IndexOf(letter[letter.Length-1])+1]).ToString() );
        }
      }
      //return the first letter of the alphabet
      return alphabet[0].ToString();
    }
