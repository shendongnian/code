		protected static string GetProjectFSPath() {
			return String.Format("{0}\\{1}", 
               Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName,
               System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
		}
