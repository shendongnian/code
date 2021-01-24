    using System.Collections.Generic;
    using System.Linq;
    namespace Investigate.Samples.Linq
    {
        class Program
        {
            public class SomeEntity
            {
                public string Description { get; set; }
            }
            static void Main(string[] args)
            {
                //Mock some entities
                List<SomeEntity> someEntities = new List<SomeEntity>()
                {
                    new SomeEntity() { Description = "" },
                    new SomeEntity() { Description = "1" },
                    new SomeEntity() { Description = "I am good" },
                };
                //Linq: Where to filter out invalids, then category to result with  ToDictionary
                Dictionary<bool, SomeEntity> filteredAndVlidated = someEntities.Where(p => !string.IsNullOrWhiteSpace(p.Description)).ToDictionary(p => (p.Description.Length > 1));
                /* Output:
                 *  False: new SomeEntity() { Description = "1" }
                 *  True: new SomeEntity() { Description = "I am good" }
                 * */
            }
        }
    }
