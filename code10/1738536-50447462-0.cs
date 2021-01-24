      using System.Linq;                     // To reverse single word
      using System.Text.RegularExpressions;  // To match the words within the text
      ... 
      // Let's elaborate the test example: add
      //  1. some punctuation - ()!. - to preserve it 
      //  2. different white spaces (spaces and tabulation - \t)
      //     to add difficulties for naive algorithms
      //  3. double spaces (after "to") to mislead split based algorithms
      string input = "I want to  reverse all\todd words (odd words only!).";
 
      int index = 0;                                // words' indexes start from zero
      string result = Regex.Replace(
        input,
       "[A-Za-z']+",
        match => index++ % 2 == 0 
          ? match.Value                             // Even words intact
          : string.Concat(match.Value.Reverse()));  // Odd words reversed
      Console.WriteLine(result);
