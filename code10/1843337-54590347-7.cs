    public class ChangePositioningPlan
	{
		public bool SomePropertyMissing { get; set; }
		public bool SomeOtherPropertyMissing { get; set; }
	}
	public class SomeObject : ActionResult
	{
		private ChangePositioningPlan _command;
		public SomeObject(ChangePositioningPlan command)
		{
			_command = command;
			_command.SomePropertyMissing = true; //Error 
		}
		public override void ExecuteResult(ControllerContext context)
		{
			if (_command.SomePropertyMissing)
			{
				context.HttpContext.AddError(new ArgumentException("GetFeedback: Something was not found!"));
				return; //Whether you want to return or continue execution?
			}
			if (_command.SomeOtherPropertyMissing)
			{
				context.HttpContext.AddError(new Exception("ShowInfo: Something else was not found!"));
				return; //Whether you want to return or continue execution?
			}
		}
	}
	public class HomeController : Controller
	{
		public ActionResult Index(ChangePositioningPlan command)
		{
			return new SomeObject(command);
		}
	}
