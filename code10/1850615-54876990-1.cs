     var regex = new Regex(Pattern);
     var matches = regex.Matches(TheText);
     var results = new List<string>();
     var currentIndex = 0;
     foreach (var match in matches.Cast<Match>())
     {
         var lastIndex = currentIndex;
         //pickup any undelimited text at the beginning or between delimited groups
         if (match.Index != currentIndex)
         {
             var unDelimited = TheText.Substring(currentIndex, match.Index - lastIndex);
             results.Add(unDelimited);
             currentIndex += unDelimited.Length;
         }
         results.Add(match.Groups[0].ToString());
         currentIndex += match.Length;
     }
     //finally pickup any undelimited text at the end
     if (TheText.Length > currentIndex)
     {
         results.Add(TheText.Substring(currentIndex));
     }
