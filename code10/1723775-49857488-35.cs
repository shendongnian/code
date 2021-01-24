    private bool Action(List<float> floats, List<float> list)
    {
       if (floats.Count != list.Count)
          return false; // sanity check
    
       for (int i = 0; i < list.Count; i++)
       {
          // nan is a special case as there is more than one possible bit value
          // for it
          if (  floats[i] != list[i] && !float.IsNaN(floats[i]) && !float.IsNaN(list[i]))
             return false;
       }
    
       return true;
    }
