         if (filesCount.ContainsKey(sanitized))
         {
             filesCount[sanitized]++;
         }
         else
         {
           filesCount.Add(sanitized, 1);
         }
        
         string newFileName = String.Format("{0}{1}.{2}", 
                                            Path.GetFileNameWithoutExtension(sanitized),
                                            filesCount[sanitized].ToString(),
                                            Path.GetExtension(sanitized));
        
         string newFilePath = Path.Combine(Path.GetDirectoryName(sanitized), newFileName);
         System.IO.File.Move(files2, newFileName);
