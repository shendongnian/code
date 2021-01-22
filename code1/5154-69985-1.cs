    var meas = new int[] { 3, 6, 9, 12, 15, 18 };
    using (mocks.Record())
    {
    	int forMockMethod = 0;
    	SetupResult.For(mocked_class.GetValue()).Do(
    		new Func<int>(() => meas[forMockMethod++])
    		);
    }
    
    using(mocks.Playback())
    {
    	foreach (var i in meas)
    		Assert.AreEqual(i, mocked_class.GetValue());
    }
