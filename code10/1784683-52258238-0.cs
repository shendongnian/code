    public enum ActionResult
	{
		NoResult,
		Fail,
		Pass,
		Exception
	}
	public struct TestActionResult
	{
	    public TestActionResult(ActionResult initialResult)
	    {
		    Result = initialResult;
		}
		private static readonly TestActionResult PassResult = new TestActionResult { Result = ActionResult.Pass };
		private static readonly TestActionResult FailResult = new TestActionResult { Result = ActionResult.Fail };
		public ActionResult Result { get; set; }
		public static implicit operator TestActionResult(bool b)
		{
			return b ? PassResult : FailResult;
		}
		public static implicit operator bool(TestActionResult tar)
		{
			return tar.Result == ActionResult.Pass;
		}
	}
