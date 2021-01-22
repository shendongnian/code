    public interface ISizedPics
    {
    	int Width {get; }
    	int Height {get; }
    	void Save(Guid userId)
    }
    pubic class ProfilePics, iSizedPics
    {
    	public int Width { get { return 200; } }
    	public int Height { get { return 160; } }
    	public void Save(Guid UserId)
    	{
    		//Do your save here
    	}
    }
