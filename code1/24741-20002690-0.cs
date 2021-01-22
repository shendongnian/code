    void Main()
    {
    	StatusFilterEnum x = StatusFilterEnum.Standard | StatusFilterEnum.Saved;
    	bool isAll = (x & StatusFilterEnum.All) == StatusFilterEnum.All;
    	//isAll is false but the naive user would expect true
    	isAll.Dump();
    }
    [Flags]
    public enum StatusFilterEnum {
          Standard =0,
          Saved =1,	  
          All = ~0 
    }
