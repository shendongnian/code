    public class ModelItemConfiguration : EntityTypeConfiguration<ModelItem>
    {
        public ModelItemConfiguration()
        {
            this.HasMany(x => x.Prop_InputNodes);
        }
	}
