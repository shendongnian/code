    public static class Extensions
    {
       public static IEnumerable<List<Message>> Split(this IEnumerable<Message> source, int chunk)
       {
          var list = new List<Message>();
          var accum = 0;
          foreach (var message in source)
          {
             accum += message.Size;
             if (accum > chunk)
             {
                yield return list;
                list.Clear();
                accum = message.Size;
             }
             list.Add(message);
          }
          yield return list;
       }
    }
