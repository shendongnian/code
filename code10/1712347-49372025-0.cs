    public ActionResult Teams()
    {  
        //Covert JSON to .net object using Deserialize method
        var jsonString ="[{\"id\":\"20\",\"name\":\"System Team\"}]";
        JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        List<Teams> listTeams = (List<Teams>)javaScriptSerializer.Deserialize(jsonString,typeof(List<Teams>));
        var teamList = new List<SelectListItem>();
        foreach (Teams teams in listTeams)
        {
            var listItem = new SelectListItem{ Value = teams.id, Text = teams.name };
            teamList.Add(listItem);
        }
        
        ViewData["teamList"] = teamList;
