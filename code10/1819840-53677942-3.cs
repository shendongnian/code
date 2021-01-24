    using System;
    using System.Collections.Generic;
    
    public class Program
    {
        public static List<string> KeySortItems { get; set; } = new List<string>()
        {
            "Username",
            "Password",
            "Item not in Dictionary",
            "SampleRequestValue",
            "SampleComplexRequest"
        };
    
        public static List<string> ValueSortItems { get; set; } = new List<string>()
        {
            "Mathew",
            "1234",
            "Item not in Dictionary",
            "Sample Request",
            "Something Complex"
        };
    
        public static Dictionary<string, string> DictionaryItems { get; set; } = new Dictionary<string, string>()
        {
            ["Password"] = "1234",
            ["Username"] = "Mathew",
            ["SampleComplexRequest"] = "Something Complex",
            ["SampleRequestValue"] = "Sample Request"
        };
    
    
        public static void Main()
        {
            Console.WriteLine("Original Dictionary");
            foreach (var kv in DictionaryItems)
            {
                Console.WriteLine($"{kv.Key} : { kv.Value}");
            }
    
    
            Console.WriteLine("\nSorted by Key");
            foreach (var kv in DictionaryItems.ListOrderByKey(KeySortItems))
            {
                Console.WriteLine($"{kv.Key} : { kv.Value}");
            }
    
            Console.WriteLine("\nSorted by Value");
            foreach (var kv in DictionaryItems.ListOrderByValue(ValueSortItems))
            {
                Console.WriteLine($"{kv.Key} : { kv.Value}");
            }
    
            Console.WriteLine("\nSorted by Keys via func");
            foreach (var kv in DictionaryItems.ListOrderBy(KeySortItems, (kv, value) => kv.Key.Equals(value)))
            {
                Console.WriteLine($"{kv.Key} : { kv.Value}");
            }
    
            Console.ReadKey();
        }
    }
    
    public static class Extensions
    {
        public static IEnumerable<KeyValuePair<TKey, TValue>> ListOrderByKey<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, List<TValue> list)
        {
            foreach (var value in list)
                foreach (var kv in dictionary)
                    if (kv.Key.Equals(value))
                        yield return kv;
        }
    
        public static IEnumerable<KeyValuePair<TKey, TValue>> ListOrderByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, List<TValue> list)
        {
            foreach (var value in list)
                foreach (var kv in dictionary)
                    if (kv.Value.Equals(value))
                        yield return kv;
        }
    
        public static IEnumerable<KeyValuePair<TKey, TValue>> ListOrderBy<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, List<TValue> list, Func<KeyValuePair<TKey, TValue>, TValue, bool> func)
        {
            foreach (var value in list)
                foreach (var kv in dictionary)
                    if (func.Invoke(kv, value))
                        yield return kv;
        }
    }
    
    //OUTPUT
    //Original Dictionary
    //Password : 1234
    //Username : Mathew
    //SampleComplexRequest : Something Complex
    //SampleRequestValue : Sample Request
    
    //Sorted by Key
    //Username : Mathew
    //Password : 1234
    //SampleRequestValue : Sample Request
    //SampleComplexRequest : Something Complex
    
    //Sorted by Value
    //Username : Mathew
    //Password : 1234
    //SampleRequestValue : Sample Request
    //SampleComplexRequest : Something Complex
    
    //Sorted by Keys via func
    //Username : Mathew
    //Password : 1234
    //SampleRequestValue : Sample Request
    //SampleComplexRequest : Something Complex
