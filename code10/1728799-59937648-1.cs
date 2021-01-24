    public class SomeEntity
    {
        [DoNotPatch]
	    public int SomeNonModifiableProperty { get; set; }
    	public string SomeModifiableProperty { get; set; }
    }
