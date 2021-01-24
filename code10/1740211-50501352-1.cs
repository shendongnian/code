	public class GradeController : Controller
	{
		private readonly IGradeListModelFactory _gradeListModelFactory;
		public GradeController(IGradeListModelFactory gradeListModelFactory){
			_gradeListModelFactory = gradeListModelFactory;
		}
		public ActionResult List()
		{
			string country = // identify country
			GradeListModelBase model = _gradeListModelFactory.GetGradeListModel(country);
		
			 model.CalculateGrade();
			 model.GetGrade();
			 return View("List", model)
		}
	}
