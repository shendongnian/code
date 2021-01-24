    public abstract class BasePasswordRequirements
    {
    	public abstract int MaxLength { get; set; }
    	public abstract int NoUpper { get; set; }
    	public abstract int NoLower { get; set; }
    	public abstract int NoNumeric { get; set; }
    	public abstract int NoSpecial { get; set; }
    }
    
    public class PasswordRequirements : BasePasswordRequirements
    {
    	public override int MaxLength { get; set; }
    	public override int NoUpper { get; set; }
    	public override int NoLower { get; set; }
    	public override int NoNumeric { get; set; }
    	public override int NoSpecial { get; set; }
    }
