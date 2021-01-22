    public void Sort(List<Employee> list, String sortBy, String sortDirection)
    {
       PropertyInfo property = list.GetType().GetGenericArguments()[0].
                                    GetType().GetProperty(sortBy);
    
       if (sortDirection == "ASC")
       {
          return list.OrderBy(e => proeprty.GetValue(e, null));
       }
       if (sortDirection == "DESC")
       {
          return list.OrderByDescending(e => proeprty.GetValue(e, null));
       }
       else
       {
          throw new ArgumentOutOfRangeException();
       }
    }
