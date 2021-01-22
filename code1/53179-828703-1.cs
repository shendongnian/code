    [NonAction]
    public List<SelectListItem> ToSelectList(IEnumerable<Department> departments, 
                                             string defaultOption)
    {
        return ToSelectList<Department>(departments, d =>  d.Code + '-' + d.Description, d => d.Id.ToString(), defaultOption);
            
    }
