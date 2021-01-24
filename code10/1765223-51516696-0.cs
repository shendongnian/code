    using System.Reflection;
    ...
    public class Experiment {
      public int Age { get; set; }
    }
    ...
    var fieldNames = string.Join(", ", typeof(Experiment)
        .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        .Select(field => field.Name));
    Console.Write(fieldNames);
