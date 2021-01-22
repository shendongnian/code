		public static readonly DataController Data = new DataController();
		public class DataController : Controller
		{
			public const string DogAction = "dog";
			public const string CatAction = "cat";
			public const string TurtleAction = "turtle";
			protected override string Root => "data";
			public Url Dog => BuildAction(DogAction);
			public Url Cat => BuildAction(CatAction);
			public Url Turtle => BuildAction(TurtleAction);
		}
