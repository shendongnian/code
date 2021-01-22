   
     public sealed class SampleEnum : CustomEnum<SampleEnum, int>
    	{
    		public static readonly SampleEnum Element1 = new SampleEnum( "Element1", 1, "foo" );
    		public static readonly SampleEnum Element2 = new SampleEnum( "Element2", 2, "bar" );
    
    		private SampleEnum( string name, int id, string additionalText )
    			: base( name, id )
    		{
    			AdditionalText = additionalText;
    		}
    
    		public string AdditionalText { get; private set; }
    	}
