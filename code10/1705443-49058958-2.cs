    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        public static void Main(string[] args)
        {
            var dd = new Dictionary<string, Dictionary<string, string>>();
            var data = 
            "~timestamp=Mar 1 2018 3:14PM|proc=procedure A|tran=transaction 1|rowCount=987" +
            "~timestamp=Mar 1 2018 3:14PM|proc=procedure B|tran=transaction 2|rowCount=654" +
            "~timestamp=Mar 1 2018 3:14PM|proc=procedure C|tran=transaction 3|rowCount=321";
            // splitting is done here:
    
            var d = data  
                .Split(new[] { '~' }, StringSplitOptions.RemoveEmptyEntries) 
                .Aggregate(new List<Dictionary<string, string>>(), 
                (listOfDicts, part) =>
                {
                    var key = Guid.NewGuid().GetHashCode().ToString();
                    listOfDicts.Add(new Dictionary<string, string>());
                    foreach (var p in part.Split(new[] { '|' },
                                                 StringSplitOptions.RemoveEmptyEntries))
                    {
                        // limit split to 2 parts if more then 1 = inside
                        var kvp = p.Split(new[] { '=' }, 2,
                                          StringSplitOptions.RemoveEmptyEntries);
                        // either 2 or 1 is the result, handle both:
                        if (kvp.Count() == 2)
                            listOfDicts.Last()[kvp[0]] = kvp[1];
                        else
                            listOfDicts.Last()[kvp[0]] = null;
                    }
                    return listOfDicts;
                });
            // output:
            foreach (var k in d)
            {
                Console.WriteLine();
                foreach (var innerKvp in k)
                {
                    Console.WriteLine("    " + innerKvp.Key + "    " + innerKvp.Value);
                }
            }
            Console.ReadLine();
        }
    }
