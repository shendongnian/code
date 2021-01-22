    if (List1.Count == List2.Count)
    {
       for(int i = 0; i < List1.Count; i++)
       {
          if(List1[i] != List2[i])
          {
             return false;
          }
       }
       return true;
    }
    return false;
