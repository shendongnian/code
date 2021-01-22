    using System;
    
    namespace SO2856896
    {
        class GuidAttribute : Attribute
        {
            public GuidAttribute(string guidAsString)
            {
                Guid = new Guid(guidAsString);
            }
    
            public Guid Guid { get; private set; }
        }
    
        enum DictionaryType
        {
            [Guid("21EC2020-3AEA-1069-A2DD-08002B30309D")]
            RegionType,
    
            [Guid("21EC2020-3AEA-1069-A2DD-08002B30309E")]
            Nationality
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                foreach (DictionaryType dicType in Enum.GetValues(
                    typeof(DictionaryType)))
                {
                    GuidAttribute attr = (GuidAttribute)typeof(DictionaryType)
                        .GetField(dicType.ToString())
                        .GetCustomAttributes(typeof(GuidAttribute), false)[0];
                    Console.Out.WriteLine(dicType + ": " + attr.Guid);
                }
            }
        }
    }
