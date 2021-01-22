		protected static string GetProjectFSPath() {
			return String.Format("{0}\\{1}", 
               System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName,
               System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
		}
