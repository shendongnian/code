	protected void loadProjectList()
	{
		var projectsPath = userDataPath + @"\" + username + @"\Projects";
		if (Directory.Exists(projectsPath))
		{
			var projects = Directory.GetDirectories(userDataPath + @"\" + username + @"\Projects");
			//create a variable
			var innerHtml = "<table><tr><td>Name</td><td>Date modified</td></tr>";
			List<string> storedProjectNamesList = new List<string>();
			for (var i = 0; i < projects.Length; i++)
			{
				var storedProjectName = projects[i].Remove(0, projects[i].LastIndexOf('\\') + 1);
				storedProjectNamesList.Add('"' + storedProjectName + '"');
				var lastModified = System.IO.File.GetLastWriteTime(storedProjectName);
				
				//add to that variable
				innerHtml += "<tr class='" + storedProjectName + "' onclick='listViewAction(event)'><td>" + storedProjectName + "</td><td>" + lastModified + "</td></tr>";
			}
			innerHtml += "</table>";
			
			//NOW set innerhtml on the objects
			projectList_dialog1.InnerHtml = innerHtml;
			projectList_dialog2.InnerHtml = innerHtml;
			storedProjectNames = string.Join(",", storedProjectNamesList);
		}
		else
		{
			serverMessage.InnerHtml = "Code (0x3): The system cannot find the path specified.";
		}
	}
