    public static class Extensions
    {
       public static IEnumerable<List<Message>> Split(this IEnumerable<Message> source, int chunk)
       {
          var list = new List<Message>();
          var accum = 0;
          foreach (var message in source)
          {
              
             // running accumulation 
             accum += message.Size;
             if (accum > chunk)
             {
                // Yield what we have 
                yield return list;
                // Reset the list 
                list = new List<Message>();
                // n-1 pattern, so we add the next size to accumulation 
                accum = message.Size;
             }
             // add the message to the chunk
             list.Add(message):
          } 
          // Return last result if any 
          If (list.Any())
             yield return list;
       }
    }
