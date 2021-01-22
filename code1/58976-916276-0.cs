    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    class Program {
        static void Main() {
            var template = " @@3@@  @@2@@ @@__@@ @@Test ZZ@@";
            var replacement = new Dictionary<string, string> {
                    {"1", "Value 1"},
                    {"2", "Value 2"},
                    {"Test ZZ", "Value 3"},
                };
            var r = new Regex("@@(?<name>.+?)@@");
            var result = r.Replace(template, m => {
                var key = m.Groups["name"].Value;
                string val;
                if (replacement.TryGetValue(key, out val))
                    return val;
                else
                    return m.Value;
            });
            Console.WriteLine(result);
        }
    }
