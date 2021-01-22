    public static T[,] To2DArray<T>(this List<List<T>> lst)
    {
    
        if ((lst == null) || (lst.Any (subList => subList.Any() == false)))
            throw new ArgumentException("Input list is not properly formatted with valid data");
    
        int index = 0;
        int subindex;
    
        return 
    
           lst.Aggregate(new T[lst.Count(), lst.Max (sub => sub.Count())],
                         (array, subList) => 
                            { 
                               subindex = 0;
                               subList.ForEach(itm => array[index, subindex++] = itm);
                               ++index;
                               return array;
                             } );
    }
