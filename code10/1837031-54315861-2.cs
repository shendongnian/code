    public class UserKycCompositeModel
    {
    	public UserKycCompositeModel(UserDetails ud,Documents  doc)
    	{
    		this.UserDetails = ud;
    		this.Document = doc;
    	}
    	public UserDetails UserDetails {get; private set;}
    	public Documents Document {get; private set;}
    	
    }
