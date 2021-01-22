    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = false)]
    public class EnumSortAttribute : Attribute
    {
        public int SortOrder;
        public bool SortByDescription;
    }
    [EnumSort(SortByDescription=true)]
    public enum EnumSortByDescription
    {
        [Description("enO")]
        One = 1,
        [Description("2")]
        Two = 2,
        Three = 3,
        [Description("rouF")]
        Four = 4
    }
    public enum EnumCustomSortOrder
    {
        [EnumSort(SortOrder = 3)]
        One = 1,
        [EnumSort(SortOrder = 1)]
        Two = 2,
        [EnumSort(SortOrder = 2)]
        Three = 3
    }
