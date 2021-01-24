    public static int HowManyClosingTags(string startTagId, string endTagId)
    {
       // if IDs are the same, then we don't need any closing tags
       if(startTagId == endTagId )
          return 0;
       // if following ID is subsection of previous tag section, then we don't need any closing tags
       if (endTagId.IndexOf(startTagId) == 0)
          return 0;
       int i = 0;
       while (startTagId[i] == endTagId[i])
          i++;
       return startTagId.Substring(i).Count(ch => ch == '.') + 1;
    }
