    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string json = @"[
                                 {
                                     ""parentID"": 123,
                                     ""parentName"": ""Parent Name"",
                                     ""childID"": 1,
                                     ""childName"": ""First Child"",
                                     ""subChildID"": null,
                                     ""subChildName"": null
                                 },
                                 {
                                     ""parentID"": 123,
                                     ""parentName"": ""Parent Name"",
                                     ""childID"": 2,
                                     ""childName"": ""Second Child"",
                                     ""subChildID"": null,
                                     ""subChildName"": null
                                 },
                                 {
                                     ""parentID"": 123,
                                     ""parentName"": ""Parent Name"",
                                     ""childID"": 3,
                                     ""childName"": ""Third child"",
                                     ""subChildID"": 100,
                                     ""subChildName"": ""First Subchild of the third child""
                                 },
                                 {
                                     ""parentID"": 123,
                                     ""parentName"": ""Parent Name"",
                                     ""childID"": 3,
                                     ""childName"": ""Third child"",
                                     ""subChildID"": 101,
                                     ""subChildName"": ""Second subchild of the third child""
                                 }
                                ]";
    
                JArray jarr = JArray.Parse(json);
    
                IEnumerable<ParentObject> parents = jarr.GroupBy(t => ((int?)t["parentID"], (string)t["parentName"]))
                                                        .Select(pg => new ParentObject
                                                        {
                                                            parentID = pg.Key.Item1,
                                                            parentName = pg.Key.Item2,
                                                            children = pg.GroupBy(t => ((int?)t["childID"], (string)t["childName"]))
                                                        .Select(cg => new ParentObject.ChildObject()
                                                        {
                                                            childID = cg.Key.Item1,
                                                            childName = cg.Key.Item2,
                                                            subChildren = cg.Select(t => new ParentObject.ChildObject.SubChildObject()
                                                            {
                                                                subChildID = (int?)t["subChildID"],
                                                                subChildName = (string)t["subChildName"]
                                                            }).Where(s => s.subChildID != null).ToList()
                                                        }).Where(c => c.childID != null).ToList()
                                                        }).Where(p => p.parentID != null).ToList();
    
                json = JsonConvert.SerializeObject(parents, Formatting.Indented);
    
                Console.WriteLine(json);
    
                Console.ReadKey();
            }
        }
    
        public class ParentObject
        {
            public int? parentID { get; set; }
            public string parentName { get; set; }
            public List<ChildObject> children { get; set; }
    
            public class ChildObject
            {
                public int? childID { get; set; }
                public string childName { get; set; }
                public List<SubChildObject> subChildren { get; set; }
    
                public class SubChildObject
                {
                    public int? subChildID { get; set; }
                    public string subChildName { get; set; }
                }
            }
        }
    }
