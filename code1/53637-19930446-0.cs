    using Caliburn.Micro;
    // ...
    /// <summary>
    /// Default view-model's ctor without parameters.
    /// </summary>
    public SomeViewModel()
	{
		if(Execute.InDesignMode)
		{
			//Add fake data for design-time only here:
			//SomeStringItems = new List<string>
			//{
			//	"Item 1",
			//	"Item 2",
			//	"Item 3"
			//};
		}
	}
