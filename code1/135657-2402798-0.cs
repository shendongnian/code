    class Foo
    {
        public virtual IProfile Profile { get; set; }
    }
    public class FooMap : ClassMap<Foo>
    {
        public FooMap()
        {
            ReferencesAny(m => m.Profile)
                .EntityTypeColumn("ProfileType")
                .EntityIdentifierColumn("ProfileId")
                .AddMetaValue<CityProfile>("CityProfile")
                .AddMetaValue<CountryProfile>("CountryProfile")
                .AddMetaValue<RegionProfile>("RegionProfile")
                .IdentityType(identity => typeof(int));
        }
    }
