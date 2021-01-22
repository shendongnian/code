    internal static class Prototype
    {
      public static T DeepCopy<T>(this IPrototype<T> target)
      {
        T copy;
        using (var stream = new MemoryStream())
        {
          var formatter = new BinaryFormatter();
          formatter.Serialize(stream, (T)target);
          stream.Seek(0, SeekOrigin.Begin);
          copy = (T) formatter.Deserialize(stream);
          stream.Close();
        }
        return copy;
      }
    }
