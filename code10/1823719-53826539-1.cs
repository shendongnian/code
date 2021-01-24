    public async Task<IActionResult> UploadFile()
    {
         var formFile = Request.Form.Files?.FirstOrDefault();
         var canParse = Request.Form.TryGetValue("model", out var model);
         if (canParse)
         {
              var data = JsonConvert.DeserializeObject<Model>(model.ToString());
         }
    
         return Ok();
    }
