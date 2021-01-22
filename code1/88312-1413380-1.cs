    private void ForEachOnNestedDates(List<DateTime[]> list, Action<DateTime> action)
    {
       // You could easily use the linq from above or...
       //list.ForEach(change => change.ToList().ForEach(action));
       // Use your code...
       for (int i = 0; i < changes.Count; i++)
       {
          for(int j = 0; j < changes[i].Length; j++)
          {
              action.Invoke(changes[i][j]);
          }
       }
    }
