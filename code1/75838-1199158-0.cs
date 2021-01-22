    public class CRMLazyLoadPrefs : ICloneable
    {
    	public bool Core { get; set; }
    	public bool Events { get; set; }	
    	public bool SubCategories { get; set; }
    	public OrganisationLazyLoadPrefs { get; set; }
    
    	public object Clone()
    	{
    		CRMLazyLoadPrefs _prefs = new CRMLazyLoadPrefs();
    		// firstly, shallow copy the booleans
    		_prefs	= (CRMLazyLoadPrefs)this.MemberwiseClone();
    		// then deep copy the other bits
    		_prefs.Organisation = (OrganisationLazyLoadPrefs)this.Organisation.Clone();
    	}
    }
