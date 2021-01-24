        public int MakeSumWithoutDuplications(List<ObjectName> a, List<ObjectName> b)
    	{
    		return a.Union(b).Sum(x => x.Value);
    	}
        public int MakeGeneralSum(List<ObjectName> a, List<ObjectName> b)
    	{
    		return a.Concat(b).Sum(x => x.Value);
    	}
