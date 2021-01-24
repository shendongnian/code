    public class StudentController : Controller 
    {
         public async Task<IActionResult> SaveStudent([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                  _dbContext.Students.Add(student);
                  await _dbContext.SaveChangesAsync();
                  return Json(true)
            }
            
           return Json(false);
        }
    }
    
