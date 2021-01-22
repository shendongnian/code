    interface IFilterCondition
    {
        List<Name> ApplyFilter(List<Name> namesToFilter);
    }
    
    abstract class FilterName : IFilterCondition
    {
        public List<Name> ExcludeList { get; set; }
    
        public virtual List<Name> ApplyFilter(List<Name> namesToFilter)
        {
            // Check Exclude List
            return namesToFilter;
        }
    }
    
    class FilterFirstName : FilterName
    {
        public char StartCharacter{ get; set; }
    
        public override List<Name> ApplyFilter(List<Name> namesToFilter)
        {
            namesToFilter = base.ApplyFilter(namesToFilter);
    
            // Check Start Character
            return namesToFilter;
        }
    }
    
    class FilterLastName : FilterName
    {
    }
