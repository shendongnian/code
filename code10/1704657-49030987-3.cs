    public IActionResult GetDDL(string id)
    {
        var result = _repo.GetData(id);
        var withProp = result.Select(x => new { Text = x });
        var json = JsonConvert.SerializeObject(withProp);      
        return Json(json);
        //Or shorter:
        var result = _repo.GetData(id).Select(x => new { Text = x });
        var json = JsonConvert.SerializeObject(result);      
        return Json(json); 
    }
