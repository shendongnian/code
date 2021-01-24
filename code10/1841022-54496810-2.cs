    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    string jsonFilePath = "1.json";
    
                    string propName = "arena_id";
    
                    RootObject[] objects = SearchObjectsWithProperty<RootObject, int>(jsonFilePath, propName, 69421, CancellationToken.None).ToArray();
    
                    System.Diagnostics.Debugger.Break();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    System.Diagnostics.Debugger.Break();
                }
            }
    
            static IEnumerable<T> SearchObjectsWithProperty<T, V>(string jsonFilePath, string propName, V propValue, CancellationToken cancellationToken) where V : IEquatable<V>
            {
                using (TextReader tr = File.OpenText(jsonFilePath))
                {
                    using (JsonTextReader jr = new JsonTextReader(tr))
                    {
                        StringBuilder currentObjectJson = new StringBuilder();
    
                        while (jr.Read())
                        {
                            cancellationToken.ThrowIfCancellationRequested();                        
                            if (jr.TokenType == JsonToken.StartObject)
                            {
                                currentObjectJson.Clear();
    
                                using (TextWriter tw = new StringWriter(currentObjectJson))
                                {
                                    using (JsonTextWriter jw = new JsonTextWriter(tw))
                                    {
                                        jw.WriteToken(jr);
    
                                        string currObjJson = currentObjectJson.ToString();
    
                                        JObject obj = JObject.Parse(currObjJson);
    
                                        if (obj[propName].ToObject<V>().Equals(propValue))
                                            yield return obj.ToObject<T>();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    
        public class RootObject
        {
            public string @object { get; set; }
            public string id { get; set; }
            public string oracle_id { get; set; }
            public int[] multiverse_ids { get; set; }
            public int mtgo_id { get; set; }
            public int arena_id { get; set; }
        }
    }
