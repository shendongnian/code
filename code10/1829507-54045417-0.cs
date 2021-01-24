    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Extensions.Caching.Memory;
    class Program
    {
        static void Main(string[] args)
        {
            var query1 = new Query { Parts = { new List<string> { "abc", "def", "ghi" } } };
            var query2 = new Query { Parts = { new List<string> { "abc", "def", "ghi" } } };
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            memoryCache.Set(("typeOfCache", query1), new object());
            var found = memoryCache.TryGetValue(("typeOfCache", query2), out var something);
            Console.WriteLine(found);
        }
        public class Query : IEquatable<Query>
        {
            public List<List<string>> Parts { get; } = new List<List<string>>();
            public bool Equals(Query other)
            {
                if (ReferenceEquals(this, other)) return true;
                if (ReferenceEquals(other, null)) return false;
                return this.Parts.Zip(other.Parts, (x, y) => x.SequenceEqual(y)).All(b => b);
            }
        
            public override bool Equals(object obj)
            {
                return Equals(obj as Query);
            }
        
            public override int GetHashCode()
            {
                return this.Parts.SelectMany(p => p).Take(10).Aggregate(17, (acc, p) => acc * 23 + p?.GetHashCode() ?? 0);
            }
        }
    }    
