    public static class Extensions
    {
       public static T[] RemoveElement<T>(this T[] source, int index)
          where T : new()
       {
    
          if(index >= source.Length) throw new ArgumentOutOfRangeException(nameof(index));
         
          // create new array
          var result = new T[source.Length - 1];
          // Copy the first part
          Array.Copy(source, 0, result, 0, index);
          // Copy the second part
          Array.Copy(source, index+1, result, index, source.Length - (index+1));
    
          return result;
       }
    } 
