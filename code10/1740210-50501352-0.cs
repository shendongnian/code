	public interface IGradeListModelFactory{
		  GradeListModelBase GetGradeListModel(string country);
	}
	public class GradeListModelFactory : IGradeListModelFactory
	{
		public GradeListModelBase GetGradeListModel(string country){
			GradeListModelBase gradeListModelBase = null;
			switch(country){
				case "x":
						gradeListModelBase = new GradeListModelForX();
					break;
				case "y":
						gradeListModelBase = new GradeListModelForY();
					break;
			}
			return gradeListModelBase;
		}
	}
