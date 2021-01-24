    public class EntityType
    {
        ...
        public int MyPropertyId { get; set; }
        [ForeignKey( "MyPropertyId" )]
        public MyProperty MyProperty { get; set; }
    }
    ...
    Entities[i].MyPropertyId = ExternalIds[i]
