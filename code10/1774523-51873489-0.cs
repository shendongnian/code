    public static IEnumerable<SelectListItem> GetProjectType()
        {
        [Required(Errormessage="message")] // just add this in your model
        List<SelectListItem> Project_Type = new List<SelectListItem>();
    
        Project_Type.Add(new SelectListItem() { Text = "type1" });
        Project_Type.Add(new SelectListItem() { Text = "type2" });
        Project_Type.Add(new SelectListItem() { Text = "type3" });
        Project_Type.Add(new SelectListItem() { Text = "type4" });
    
        return Project_Type;
        }
