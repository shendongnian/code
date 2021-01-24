    public HomeController(GettingWords repository){
        _repository = repository;
    }
    [HttpPost]
    public async Task<JsonResult> SearchWord([FromBody] RequestModel model){
        var result = await _repository.GettingWordAsync(model.word, model.adress);
        return Json(result);
    }
