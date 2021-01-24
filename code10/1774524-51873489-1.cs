    public static IEnumerable<SelectListItem> GetProjectType()
    {
    
        List<SelectListItem> Project_Type = new List<SelectListItem>();
        Project_Type.Add(new SelectListItem() { Text = "type1",value="1" });
        Project_Type.Add(new SelectListItem() { Text = "type2",value="2" });
        Project_Type.Add(new SelectListItem() { Text = "type3",value="3" });
        Project_Type.Add(new SelectListItem() { Text = "type4",value="4"});
  
    return Project_Type;
    }
    
