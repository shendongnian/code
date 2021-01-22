    class Member
    {
    	public virtual string Label { get; set; }
    	public double Thickness { get; set; }
    	public double Width { get; set; }
    	public double Length { get; set; }
    	public double GetVolume()
    	{
    		return Thickness * Width * Length;
    	}
    }
    
    class OtherMember : Member
    {
    	string label;
    
    	public override string Label
    	{
    		get { return this.label; }
    		set { this.label = value; }
    	}
    }
