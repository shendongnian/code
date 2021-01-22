    //Define all global class variables
    List<int> m_lInts = New List<int>();
    List<string> m_lStrs = New List<string>();
    
    public static object FindMyObject(string sSearchCritera)
    {
      //Initialize the variable
      object result = null;
      
      if (result == null)
      {
        //Search the ints list
        foreach(int i in m_lInts)
        {
          if (i.ToString() == sSearchCritera)
          {
            //Give it a value
            result = (int)i;
          }
        }
      }
      
      if (result == null)
      {
        //Search the ints list
        foreach(string s in m_lStrs)
        {
          if (s == sSearchCritera)
          {
            //Give it a value
            result = (string)s;
          }
        }
      }
      
      //Return the results
      return result;
    }
