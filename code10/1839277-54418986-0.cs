     foreach (string filename in filenames)
     {
         FileInfo[] fi = di.GetFiles(filename);
         if (fi != null && fi.Length > 0)
         {
             // Consider if you'd like to check that only one file was found
             // This might happen because GetFiles considers its input as a pattern
             // However if you are using full file names (which is most likely the case), that shouldn't be necessary
             fi[0].Delete();
         }
     }
