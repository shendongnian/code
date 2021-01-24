    public class CustomerRectangle : Rectangle
    {
    
    	public string Name { get; set; }
    	public CustomerRectangle(float llx, float lly, float urx, float ury,string name) : 
    		base( llx,  lly,  urx,  ury)
    	{
    		Name = name;
    	}
    }
