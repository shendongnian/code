    public List<T> ConvertToList<T>(DataTable dt, List<T> list)
    {
        switch(list)
		{
			case List<ProductionPending> pp:
				//pp is list cast as List<ProductionPending>
				break;
			case List<ProductionRecent> pr:
				//pr is list cast as List<ProductionRecent>
				break;
			case List<MirrorDeployments> md:
				//md is list cast as List<MirrorDeployments>
				break;			
		}
        return list;
    }
