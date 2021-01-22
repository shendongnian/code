    public List<Employee> Sort(List<Employee> list, String sortBy, String sortDirection)
    {
       PropertyInfo property = list.GetType().GetGenericArguments()[0].
                                    GetType().GetProperty(sortBy);
    
       if (sortDirection == "ASC")
       {
          return list.OrderBy(e => property.GetValue(e, null));
       }
       if (sortDirection == "DESC")
       {
          return list.OrderByDescending(e => property.GetValue(e, null));
       }
       else
       {
          throw new ArgumentOutOfRangeException();
       }
    }
