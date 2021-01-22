    public class CloneableList<T> : List<T>, ICloneable where T : ICloneable
    {
      public object Clone()
      {
        var clone = new List<T>();
        ForEach(item => clone.Add((T)item.Clone()));
        return clone;
      }
    }
