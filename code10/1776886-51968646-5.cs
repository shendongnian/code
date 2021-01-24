    string lineWithAsterisk;
    foreach (string currentString in fileHash)
    { 
         boolean found=i.Contains("*");
         /*
         alternative, you should try which code performs faster: 
         boolean found=i.charAt(i.Length-1).Equals("*");
         */
         if (found)
         {
             lineWithAsterisk = currentString;
             lineWithAsterisk=lineWithAsterisk.Remove(lineWithAsterisk.Length-1);
             continue;
         }
         if(currentString.StartsWith(lineWithAsterisk))
         {
             fileListToRemove.Add(currentString);
         }
    }
