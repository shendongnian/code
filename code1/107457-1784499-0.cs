    List pick(Int num, List list)
    {
      if (num == 1) // base case
      {
        return list
      }
      else // recurring case
      {
        var results = []
        foreach (item in list)
        {
          alteredList = list.copy().remove(item)
          results.add([item] + pick(num - 1, alteredList))
        }
        return results
      }
    }
