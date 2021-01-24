    while ((line = bodytext.ReadLine()) != null)
    {
        foreach(string ending in MYLISTOFCOMMONENDINGS)
                         {
                             if (line.StartsWith(ending))
                                 return sb.ToString();  //we are done
    //here sb is a string builder consuming new lines
                         }
            //read the line and check spelling
    } 
