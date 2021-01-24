    public class PersonModel : IComparable
    {
    	public string Name { get; set; }
    	public DateTime Dt { get; set; }
    
    	public int CompareTo(object obj)
    	{
    		var compareObj = obj as PersonModel;
    		return compareObj.Dt > this.Dt? 0:1;
    	}
    }
    
    var query = dt.AsEnumerable().Max(x => 
    	new PersonModel {
    		Name = x[0].ToString(),
    		Dt = DateTime.ParseExact(x[1].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture)
    	}
    );
