    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    
    public class Test
    {
        static void Main()
        {
            // Just types covering some different assemblies
            var sampleTypes = new[] { typeof(List<>), typeof(string), 
                                      typeof(Enumerable), typeof(XmlReader) };
            
            // All the types in those assemblies
            var allTypes = sampleTypes.Select(t => t.Assembly)
                                      .SelectMany(a => a.GetTypes());
            
            // Grouped by namespace, but indexable
            var lookup = allTypes.ToLookup(t => t.Namespace);
            
            foreach (var type in lookup["System"])
            {
                Console.WriteLine("{0}: {1}", 
                                  type.FullName, type.Assembly.GetName().Name);
            }
        }
    }
