    public partial class MyObjectContext : BrandonHaynes.ModelAdapter.EntityFramework.AdaptingObjectContext
    {
            public MyObjectContext() 
	    	: base(myConnectionString, 
	  		new ConnectionAdapter(
				new TablePrefixModelAdapter("Prefix", 
					new TableSuffixModelAdapter("Suffix")), 
			System.Reflection.Assembly.GetCallingAssembly()))
		{
		...
		}
