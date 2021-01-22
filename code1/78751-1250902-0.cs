	namespace SharedProject
	{
		public class X
		{
			protected X() {	}
			public static void SharedMethod() { }
		}
	}
	
	namespace PrimaryProject
	{
		public class X : SharedProject.X
		{
			protected X() {	}
			public static void ProjectMethod() { }
		}
	}
