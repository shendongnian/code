     [HttpGet("[action]/{id}")]
     public IActionResult public Product GetById(int id, [FromHeader(Name = "Accept")] string mediaType)
            {
               if (mediaType == "application/vnd.myvendormediatype")
               {
                     var data = GetYourData(...)
                     return Json(data);
               }
               else return View("YourDefaultView");
            }
