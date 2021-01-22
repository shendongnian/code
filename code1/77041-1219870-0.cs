    void ModifyList<List<object> list)
    {
       for (int i=0; i<list.Count; i++)
       {
          list[i] = list[i].ToString();
       }
    }
