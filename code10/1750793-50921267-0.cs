    var conventionPack = new ConventionPack { new IgnoreIdFieldConvention() };
    ConventionRegistry.Register("Do not deserialize _id field", conventionPack, t => t.Namespace == "Some.Name.Space"); // via namespace
    ConventionRegistry.Register("Do not deserialize _id field", conventionPack, t => t != typeof(SyncData<>)); // white-list approach
    ConventionRegistry.Register("Do not deserialize _id field", conventionPack, t => typeof(IDisposable).IsAssignableFrom(t)); // via an interface
    public class IgnoreIdFieldConvention : ConventionBase
    {
        public void Apply(BsonMemberMap memberMap)
        {
            memberMap.ClassMap.UnmapProperty("Id");
        }
    }
