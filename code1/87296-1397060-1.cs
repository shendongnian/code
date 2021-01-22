    /// <summary>
    /// Appends a number of tabs to the string builder
    /// </summary>
    /// <param name="str">The string builder to append to</param>
    /// <param name="iTabIndex">The number of tabs to append to</param>
    public void AddTabs(System.Text.StringBuilder str, int iTabIndex)
    {
       for (int i = 0; i <= iTabIndex; i++) 
       {
          str.Append("\t");
       }
    }
