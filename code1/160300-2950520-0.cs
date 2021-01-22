    public void FindConflicts(IEnumerable<TextBox> tbList, IList<TextBox> conflicts, string test)
    {
       foreach(TextBox tb in tbList)
       {
          if(tb.Text == test)
          {
              conflicts.Add(tb);
          }
       }
    }
