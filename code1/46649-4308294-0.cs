	public partial class PetStore //: IPetStore
    {
		
		public PetStore()
        { /*Constructor*/      }
        public virtual Guid? PetStoreUUID { get; set; }
        public virtual byte[] TheVersionProperty { get; set; }
        public virtual string PetStoreName { get; set; }
        public virtual DateTime CreateDate { get; set; }		
	
		
	}
    public class PetStoreMap : ClassMap<PetStore>
    {
        public PetStoreMap()
        {
            Id(x => x.PetStoreUUID).GeneratedBy.GuidComb();
            OptimisticLock.Version();
            Version(x => x.TheVersionProperty)
                .Column("MyVersionColumn")
                .Not.Nullable()
                .CustomSqlType("timestamp")
                .Generated.Always();
     
                Map(x => x.PetStoreName);
                Map(x => x.CreateDate);
        }
    }
