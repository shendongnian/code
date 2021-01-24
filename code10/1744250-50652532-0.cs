    class LocationLoadoutDef
    {
    	public LocationLoadoutDef()
    	{
    		Head = new Prop();
    		LeftArm = new Prop();
    		RightArm = new Prop();
    		CenterTorso = new Prop();
    		LeftTorso = new Prop();
    		RightTorso = new Prop();
    		LeftLeg = new Prop();
    		RightLeg = new Prop();
    	}
    
    	public Prop Head { get; set; }
    	public Prop LeftArm { get; set; }
    	public Prop RightArm { get; set; }
    	public Prop CenterTorso { get; set; }
    	public Prop LeftTorso { get; set; }
    	public Prop RightTorso { get; set; }
    	public Prop LeftLeg { get; set; }
    	public Prop RightLeg { get; set; }
        ...
    }
    
    class Prop
    {
    	public float CurrentInternalStructure { get; set; }
        ...
    }
