    using System.Collections.Generic;
    using System.Reflection;
    
    namespace ConsoleApp1
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                List<KeyValues> kv = new List<KeyValues>();
                kv.Add(new KeyValues() { Key = "SystemId", Value = "12" });
                kv.Add(new KeyValues() { Key = "SystemName", Value = "LTPVBN21" });
                kv.Add(new KeyValues() { Key = "Location", Value = "NJ2" });
    
                SystemInformation si = new SystemInformation();
    
                foreach (KeyValues k in kv)
                {
                    PropertyInfo pi = typeof(SystemInformation).GetProperty(k.Key);
    
                    pi.SetValue(si, k.Value);
                }
    
        }
    
    
        public class KeyValues
        {
            public string Key { get; set; }
            public string Value { get; set; }
        }
    
        public class SystemInformation
        {
            public string SystemId { get; set; }
    
            public string SystemName { get; set; }
    
            public string Location { get; set; }
        }
    }
    
    }
