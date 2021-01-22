		internal static string GetSourceOrInclude(bool openAndActivate)
		{
			// Look in the project for a file of the same name with the opposing extension
			ProjectItem thisItem = Commands.Application.ActiveDocument.ProjectItem;
			string ext = Path.GetExtension(thisItem.Name);
			string searchExt = string.Empty;
			if (ext == ".cpp" || ext == ".c")
				searchExt = ".h";
			else if (ext == ".h" || ext == ".hpp")
				searchExt = ".cpp";
			else
				return(string.Empty);
			string searchItemName = thisItem.Name;
			searchItemName = Path.ChangeExtension(searchItemName, searchExt);
			
			Project proj = thisItem.ContainingProject;
			foreach(ProjectItem item in proj.ProjectItems)
			{
				ProjectItem foundItem = FindChildProjectItem(item, searchItemName);
				if (foundItem != null)
				{
					if (openAndActivate)
					{
						if (!foundItem.get_IsOpen(Constants.vsViewKindCode))
						{
							Window w = foundItem.Open(Constants.vsViewKindCode);
							w.Visible = true;
							w.Activate();
						}
						else
						{
							foundItem.Document.Activate();
						}
					}
					return(foundItem.Document.FullName);
				}
			return(string.Empty);
		}
