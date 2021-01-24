    public interface IEntity
    {
    	int Id { get; set; }
    }
    	
    public interface IAuditable
    {
    	string CreatedBy { get; set; }
    	DateTime? CreatedDate { get; set; }
    	string UpdatedBy { get; set; }
    	DateTime? UpdatedDate { get; set; }
    }
    
    public class EntityConfiguration<T> : EntityTypeConfiguration<T> where T : class, IEntity, IAuditable
    {
    	public EntityConfiguration()
    	{
    		HasKey(e => e.Id);
    
    		Property(e => e.Id)
    			.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    				
    		Property(e => e.CreatedBy)
    			.IsUnicode(false)
    			.HasMaxLength(255);
    
    		Property(e => e.UpdatedBy)
    			.IsUnicode(false)
    			.HasMaxLength(255);
    	}
    }
 
