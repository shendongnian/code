    using System.Collections;
    using System.Collections.Generic;
...
    if (!ReferenceEquals(null, kvp) && (kvp is IDictionary))
            {
                foreach (DictionaryEntry entry in aSubDict)
                {
                    if (entry.Value is IDictionary)
                    {
                        Console.WriteLine("iDictionary found");
                    }
                    else
                    {
                        Console.WriteLine("SubKey = {0}, SubValue = {1}", entry.Key, entry.Value);
                    }
                }
