    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json.Linq;
    
    namespace ConsoleApp1
    {
       internal class Program
       {
          #region Static Fields and Constants
    
          private static readonly string json =
             "[" +
             "{\"Inputs\": [" +
             "{\"Input\": \"A B C\"}," +
             "{\"Input\": \"B C E \"}," +
             "{\"Input\": \"C G\"}," +
             "{\"Input\": \"D A  F\"}," +
             "{\"Input\": \"E F\"}," +
             "{\"Input\": \"F H \"}" +
             "]}" +
             "]";
    
          #endregion
    
          #region Public Methods
    
          public static void GetDependencies(char key, Dictionary<char, char[]> inputs, ref List<char> totalDependencies)
          {
             // stopping cases (the stack will unwind when all dependencies have been explored)
             if (!inputs.ContainsKey(key) || inputs[key] == null || inputs[key].Length == 0) {
                return;
             }
    
             var deps = inputs[key];
             foreach (var dep in deps) {
                // we've already added this branch of the dependency tree so go to the next dependency
                if (totalDependencies.Contains(dep)) {
                   continue;
                }
    
                // the recursion (see how this method calls itself?)
                GetDependencies(dep, inputs, ref totalDependencies);
                totalDependencies.Add(dep);
             }
          }
    
          public static string BuildDependencies(Dictionary<char, char[]> inputs)
          {
             var sb = new StringBuilder();
             foreach (var input in inputs) {
                var td = new List<char>();
                GetDependencies(input.Key, inputs, ref td);
                sb.AppendLine($"{Guid.NewGuid()}, << Dependencies for {input.Key} >> {string.Join(",", td)},\"False\"");
             }
    
             return sb.ToString();
          }
        
          #endregion
          
          private static void Main(string[] args)
          {
             var data = JArray.Parse(json);
             var values = data.SelectTokens("..Input").Select(x => x.ToString()).ToArray();
             var inputs = MakeInputs(values);
    
             Console.WriteLine(BuildDependencies(inputs));
          }
    
          private static Dictionary<char, char[]> MakeInputs(IEnumerable<string> values)
          {
             var dict = new Dictionary<char, char[]>();
             foreach (var s in values) {
                var parts = s.Where(char.IsLetterOrDigit).ToArray();
                var deps = parts.Skip(1).Take(parts.Length).ToArray();
                var key = parts[0];
    
                dict[key] = deps;
             }
    
             return dict;
          }
       }
    }
