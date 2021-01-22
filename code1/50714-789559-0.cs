    using System.Collections.Generic;
    using System.Linq;
    
    namespace CommaQuibbling
    {
        internal class Translator
        {
            public string Translate(IEnumerable<string> items)
            {
                return "{" + Join(items) + "}";
            }
    
            private static string Join(IEnumerable<string> items)
            {
                var leadingItems = LeadingItemsFrom(items);
                var lastItem = LastItemFrom(items);
    
                return JoinLeading(leadingItems) + lastItem;
            }
    
            private static IEnumerable<string> LeadingItemsFrom(IEnumerable<string> items)
            {
                return items.Reverse().Skip(1).Reverse();
            }
    
            private static string LastItemFrom(IEnumerable<string> items)
            {
                return items.LastOrDefault();
            }
    
            private static string JoinLeading(IEnumerable<string> items)
            {
                if (items.Any() == false) return "";
    
                return string.Join(", ", items.ToArray()) + " and ";
            }
        }
    }
