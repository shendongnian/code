    public class ActivityMap : ClassMap<Activity>
        {
            public ActivityMap()
            {
                Table("Activities");
                Id(x => x.Id).Column("ID").GeneratedBy.Guid();
                Map(x => x.ActivityName).Not.Nullable().Length(50);
                Map(x => x.ActivityType).CustomType<int>().Column("ActivityType").Not.Nullable();
                HasMany(x => x.ActivityParameters)
                    .KeyColumn("ActivityID")
                    .AsMap<string>(idx => idx.Column("ParameterName"), elem => elem.Column("ParameterValue"))
                    .Not.LazyLoad()
                    .Cascade.Delete()
                    .Table("ActivityParameters");
    
                DiscriminateSubClassesOnColumn("ActivityType");
            }
        }
    
        public class ImportActivityFromFileMap : SubclassMap<ImportActivityFromFile>
        {
            public ImportActivityFromFileMap()
            {
                DiscriminatorValue(ActivityType.ImportFromFile.GetKey());
            }
        }
