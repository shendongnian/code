    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false, Inherited=true)]
    public class SortOrderAttribute : Attribute
    {
        public int SortOrder { get; set; }
        public SortOrderAttribute(int sortOrder)
        {
            this.SortOrder = sortOrder;
        }
    }
