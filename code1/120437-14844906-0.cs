      /// <summary>
      /// Method to display the results in the RichTextBox, prefixed with "Results: " and with the 
      /// letters J, Q, X and Z in bold type.
      /// </summary>
      private void DisplayResults(string resultString)
      {
         resultString = MakeSubStringBold(resultString, "J");
         resultString = MakeSubStringBold(resultString, "Q");
         resultString = MakeSubStringBold(resultString, "X");
         resultString = MakeSubStringBold(resultString, "Z");
    
         rtbResults.Rtf = @"{\rtf1\ansi " + "Results: " + resultString + "}";
      }
    
    
      /// <summary>
      /// Method to apply RTF-style formatting to make all occurances of a substring in a string 
      /// bold. 
      /// </summary>
      private static string MakeSubStringBold(string theString, string subString)
      {
         return theString.Replace(subString, @"\b " + subString + @"\b0 ");
      }
