    using System;
    using System.Collections;
    
    class Permutation{
      static IEnumerable Permutations(string word){
        if (word == null || word.Length <= 1) {
          yield return word;
          yield break;
        }
    
        char firstChar = word[0];
        foreach( string subPermute in Permutations (word.Substring (1)) ) {
          int indexOfFirstChar = subPermute.IndexOf (firstChar);
          if (indexOfFirstChar == -1) indexOfFirstChar = subPermute.Length;
    
          for( int index = 0; index <= indexOfFirstChar; index++ )
            yield return subPermute.Insert (index, new string (firstChar, 1));
        }
      }
    
      static void Main(){
        foreach( var permutation in Permutations ("aab") )
          Console.WriteLine (permutation);
      }
    }
