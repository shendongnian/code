    public IActionResult GetDDL(string id)
    {
        var result = _repo.GetData(id);
        var json = JsonConvert.SerializeObject(result);      
        return Json(json);
    }
    
