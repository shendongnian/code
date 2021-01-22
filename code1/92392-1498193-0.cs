    public class AutoMappingBuddyAttribute : Attribute
    {
        public Type MappingBuddy { get; private set; }
        public AutoMappingBuddyAttribute(Type mappingBuddyType)
        {
            if (mappingBuddyType == null) throw new ArgumentNullException("mappingBuddyType");
            MappingBuddy = mappingBuddyType;
        }
        public IAutoMappingBuddy CreateBuddy()
        {
            ConstructorInfo ci = MappingBuddy.GetConstructor(new Type[0]);
            if (ci == null)
            {
                throw new ArgumentOutOfRangeException("mappingBuddyType", string.Format("{0} does not have a parameterless constructor."));
            }
            object obj = ci.Invoke(new object[0]);
            return obj as IAutoMappingBuddy;
        }
    }
