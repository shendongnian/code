    public class SomeSubclassMap : SubclassMap<SomeSubclass> {
        public SomeSubclassMap()
        {
            KeyColumn("SomeKeyColumnID");
            Map(x => x.SomeSubClassProperty);
            ...
        }
    }
