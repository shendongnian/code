	public class OneProperty
	{
		virtual public int MyInt
		{
			get;
			set;
		}
	}
	
	[Test]
	public void IntWasSet()
	{
		var prop = Rhino.Mocks.MockRepository.GenerateMock<OneProperty>();
		
		prop.MyInt = 5;
			
		prop.AssertWasNotCalled(x => x.MyInt = Arg<int>.Is.Anything);
			
		prop.VerifyAllExpectations();
	}
