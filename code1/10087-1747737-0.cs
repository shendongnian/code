		/// </summary>
		/// <param name="pathToResolve">Path to resolve</param>
		/// <param name="defaultPath">Current dir for pathes</param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">pathToResolve or defaultPath is null or empty</exception>
		public static string ResolveRelativePath(string pathToResolve, string defaultPath)
		{
			if (string.IsNullOrEmpty(pathToResolve))
			{
				throw new ArgumentNullException("pathToResolve");
			}
			if (!Path.IsPathRooted(pathToResolve))
			{
				if (string.IsNullOrEmpty(defaultPath))
				{
					throw new ArgumentNullException("defaultPath");
				}
				pathToResolve = defaultPath + @"\" + pathToResolve;
				pathToResolve = pathToResolve.Replace(@"/", @"\").Replace(@"\\", @"\");
				
				// removing things like \xxx\..\
				while (pathToResolve.Contains(Up_))
				{
					// this points to x:\temp\..[\]xxx
					int endPos = pathToResolve.IndexOf(Up_) + Up_.Length; 
					int startPos = pathToResolve.LastIndexOf(@"\", endPos-4, endPos - 5);
					pathToResolve = pathToResolve.Remove(startPos, endPos - startPos);
				}
			}
			
			return pathToResolve;
		}
