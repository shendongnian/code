    private void ForEachOnNestedDates(List<DateTime[]> list, Func<DateTime, DateTime> method)
    {
       // Use your code...
       for (int i = 0; i < list.Count; i++)
       {
          for(int j = 0; j < list[i].Length; j++)
          {
              list[i][j] = method.Invoke(list[i][j]);
          }
       }
    }
