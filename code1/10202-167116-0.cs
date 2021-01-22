  String text;
  List&lt;Char&gt; patternsToReplace;
  List&lt;Char&gt; patternsToUse;
  patternsToReplace = new List&lt;Char&gt;();
  patternsToReplace.Add('a');
  patternsToReplace.Add('c');
  patternsToUse = new List&lt;Char&gt;();
  patternsToUse.Add('X');
  patternsToUse.Add('Z');
  text = "This is a thing to replace stuff with";
  
  var allAsAndCs = text.ToCharArray()
                 .Select
                 (
                   currentItem => patternsToReplace.Contains(currentItem) 
                     ? patternsToUse[patternsToReplace.IndexOf(currentItem)] 
                     : currentItem
                 )
                 .ToArray();
            
  text = new String(allAsAndCs);
