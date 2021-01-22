    using System;
    using System.Collections.Generic;
    
    namespace SO2856896
    {
        enum DictionaryType
        {
            RegionType,
            Nationality
        }
    
        class Consts
        {
            public class DictionaryTypeId
            {
                public static Guid RegionType = new Guid("21EC2020-3AEA-1069-A2DD-08002B30309D");
                public static Guid Nationality = new Guid("21EC2020-3AEA-1069-A2DD-08002B30309E");
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<DictionaryType, Guid> table = new Dictionary<DictionaryType, Guid>();
    
                Type idType = typeof(Consts.DictionaryTypeId);
                foreach (DictionaryType dicType in Enum.GetValues(
                    typeof(DictionaryType)))
                {
                    System.Reflection.FieldInfo field = idType
                        .GetField(dicType.ToString(), 
                            System.Reflection.BindingFlags.Static
                            | System.Reflection.BindingFlags.Public);
                    Guid guid = (Guid)field.GetValue(null);
                    table[dicType] = guid;
                }
    
                foreach (DictionaryType dicType in Enum.GetValues(
                    typeof(DictionaryType)))
                {
                    Console.Out.WriteLine(dicType + ": " + table[dicType]);
                }
            }
        }
    }
