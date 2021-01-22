    if(this.NotSelectedProjects == null) {
	//build a dictionary for fast look-up
	Dictionary<string, SelectListItem> selectedProjects = new Dictionary<string, SelectListItem>();
	foreach(SelectListItem item in selectedProjectes){
		selectedProjects.Add(item.Value, SelectListItem);
	}
	//loop through all the projects
	List<SelectItem> result = new List<SelectListItem>();
	foreach(SelectListItem item in projectlist) {
		if(selectedProjects.HasKey(item.Value)){
			continue; //this project is selected
		}
		
		result.Add(item);
	}
	this.NotSelectedProjects = result;
    }
    return this.NotSelectedProjects;
