	applicationObject = await ServiceProvider.GetGlobalServiceAsync(typeof(SDTE)) as DTE2; // Was initiate in a method
	private enum SelectionTypes
	{
		Other = 0,
		InSubModules = 1,
		IsAFolder = 2,
		IsAProject = 4,
		InAProject = 8
	}
	private static List<SelectionTypes> GetSelectionTypes()
	{
		ThreadHelper.ThrowIfNotOnUIThread();
		var selectionTypes = new List<SelectionTypes>();
		EnvDTE.UIHierarchy solutionExplorer = applicationObject.ToolWindows.SolutionExplorer;
		object[] items = solutionExplorer.SelectedItems as object[];
		//{ Name = "WindowBase" FullName = "Microsoft.VisualStudio.Platform.WindowManagement.DTE.WindowBase"}
		if (items.Length > 0)
		{
			for (int i = 0; i < items.Length; i++)
			{
				var selectionType = SelectionTypes.Other;
				var selectedItem = items[0] as EnvDTE.UIHierarchyItem;
				var currentItem = selectedItem;
				var subModulesParentsCount = 0;
				var countingSubModulesParents = false;
				var nbParents = -1;
				if (currentItem.Object.GetType().FullName == "Microsoft.VisualStudio.ProjectSystem.VS.Implementation.Package.Automation.OAProject") selectionType |= SelectionTypes.IsAProject;
				if (currentItem.Object.GetType().FullName == "Microsoft.VisualStudio.ProjectSystem.VS.Implementation.Package.Automation.OAFolderItem") selectionType |= SelectionTypes.IsAFolder;
				while (currentItem != null)
				{
					nbParents++;
					if (countingSubModulesParents) subModulesParentsCount++;
					if (currentItem.Name == "SubModules")
					{
						subModulesParentsCount = 0;
						countingSubModulesParents = true;
					}
					if (currentItem.Object.GetType().FullName == "Microsoft.VisualStudio.ProjectSystem.VS.Implementation.Package.Automation.OAProject") selectionType |= SelectionTypes.InAProject;
					currentItem = currentItem.Collection.Parent as EnvDTE.UIHierarchyItem;
				}
				if (selectionType == SelectionTypes.Other && nbParents != 0) selectionType |= SelectionTypes.IsAFolder;
				
				if (subModulesParentsCount == 1)
				{
					selectionType |= SelectionTypes.InSubModules;
				}
				selectionTypes.Add(selectionType);
			}
		}
		return selectionTypes;
	}
