    class FamilyData
    {
    	public FamilyData(string code, string family)
    	{
    		Code = code;
    		Family = family;
    	}
    
    	public string Code { get; set; }
    	public string Family { get; set; }
    	public string CodeFamily { get { return string.Format("{0}\t{1}", Code, Family); } }
    }
    
    class FamilySelector : IEqualityComparer<FamilyData>
    {
    	public bool Equals(FamilyData x, FamilyData y)
    	{
    		return x.Code == y.Code && x.Family == y.Family;
    	}
    
    	public int GetHashCode(FamilyData obj)
    	{
    		return obj.Code.GetHashCode() ^ obj.Family.GetHashCode();
    	}
    }
    var source = _mfgOrdersData
    	.Select(o => new FamilyData(o.ItemWrapper.ItemClass, o.ItemWrapper.Family))
    	.Distinct(new FamilySelector())
    	.OrderBy(f => f.CodeFamily)
    	.ToList();
