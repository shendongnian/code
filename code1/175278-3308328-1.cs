    class Program
    {
      static void Main()
      {
        var file = @"C:\myFile.txt";
        var tempFile = Path.ChangeExtension(file, "tmp");
    
        using (var writer = new StreamWriter(tempFile))
        {
          ReadFile(file)
          .FilterI((i, line) => i != 1)
          .ForEach(l => writer.WriteLine(l));    
        }
    
        File.Delete(file);
        File.Move(tempFile, file);
      }
      static IEnumerable<String> ReadFile(String file)
      {
        using (var reader = new StreamReader(file))
        {
          while (!reader.EndOfStream)
          {
            yield return reader.ReadLine();
          }
        }
      }
    }
    static class IEnumerableExtensions
    {
      public static IEnumerable<T> FilterI<T>(
          this IEnumerable<T> seq, 
          Func<Int32, T, Boolean> filter)
      {
        var index = 0;
    
        foreach (var item in seq)
        {
          if (filter(index, item))
          {
            yield return item;
          }
    
          index++;
        }
      }
    
      public static void ForEach<T>(
          this IEnumerable<T> seq,
          Action<T> action)
      {
        foreach (var item in seq)
        {
          action(item);
        }
      }
    }
