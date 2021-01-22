    public class EnumModel
    {
        public int Value { get; set; }
        public string Name { get; set; }
    }
    public enum MyEnum
    {
        Name1=1,
        Name2=2,
        Name3=3
    }
    public class Test
    {
            List<EnumModel> enums = ((MyEnum[])Enum.GetValues(typeof(MyEnum))).Select(c => new EnumModel() { Value = (int)c, Name = c.ToString() }).ToList();
            // A list of Names only, does away with the need of EnumModel 
            List<string> MyNames = ((MyEnum[])Enum.GetValues(typeof(MyEnum))).Select(c => c.ToString()).ToList();
            // A list of Values only, does away with the need of EnumModel 
            List<int> myValues = ((MyEnum[])Enum.GetValues(typeof(MyEnum))).Select(c => (int)c).ToList();
            // A dictionnary of <string,int>
            Dictionary<string,int> myDic = ((MyEnum[])Enum.GetValues(typeof(MyEnum))).ToDictionary(k => k.ToString(), v => (int)v);
    }
