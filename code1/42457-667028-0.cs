    public static void DoActionsInOrder<T>(this IEnumerable<T> stream, params Action<T> actionList)
    {
         foreach(var action in actionList)
         {
              foreach(var item in stream)
              {
                   action(item);
              }
         }
    }
