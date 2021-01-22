		protected static string GetSolutionFSPath() {
			return System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
		}
		protected static string GetProjectFSPath() {
			return String.Format("{0}\\{1}", GetSolutionFSPath(), System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
		}
