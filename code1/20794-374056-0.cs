    public class SubClassMap : JoinedSubClassPart< SubClass >
    {
        public SubClassMap()
            : base("SubClassId")
        {
             Map(x => x.Name); 
             Map(x => x.SomeProperty); 
        }
    }
