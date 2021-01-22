    StringBuilder sb = new StringBuilder();
   
    for (int i = 0; i < fName.Length; i++)
    {
       if (char.IsLetterOrDigit(fName[i]))
        {
           sb.Append(fName[i]);
        }
    }
