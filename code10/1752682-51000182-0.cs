    public ResultModel checkSomething()
	{
		ResultModel retVal = new ResultModel();
		if(condition1)
		{
			retVal.DidSucceed = true;
			retVal.Source = eSource.Condition1;
		}
		else if (condiction2){
			...
		}
		
		return retVal;
	}
	class ResultModel
	{
		public bool DidSucceed {get;set;}
		public eSource Source {get;set;}
	}
