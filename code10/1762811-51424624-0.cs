      using System.Reflection;
      ...
 
      var animals = typeof(Constants.Animals)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .Where(field => field.IsLiteral)
        .Select(field => field.GetValue(null));
      Console.Write(string.Join(Environment.NewLine, animals));
