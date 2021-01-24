    using System.Linq;
    ...
    class Line : Station {
      ...
      public List<Station> GetCC() {
        return file
          .Where(item => item.Number.Contains("CC"))
          .ToList();
      }
      ...
    }
