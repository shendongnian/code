    public class ModelDto
    {
        public int Lower { get; set; }
    }
    [HttpPost]
    public IActionResult Ajax_GenerateSecretNum([FromBody]ModelDto model)
    {
        // model.Lower should contain your int
        return Json(new { success = true });
    }
