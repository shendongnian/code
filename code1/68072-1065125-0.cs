    class Member
    {
    	public string Label { get; set; }
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
    	public string CompositeLabel { get; set; }
    }
