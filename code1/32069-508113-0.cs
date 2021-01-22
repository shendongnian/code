    public class BusinessLogic
	{
		private BusinessLogicSubClass subClass;
		private BusinessLogic()
		{
		}
		public static BusinessLogic CreateBusinessLogic()
		{
			BusinessLogic bl = new BusinessLogic();
			BusinessLogicSubClass blsc = new BusinessLogicSubClass(bl);
			bl.subClass = blsc;
			return bl;
		}
	}
