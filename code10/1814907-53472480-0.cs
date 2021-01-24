    [Route("[controller]/[action]")]
    public class SurveyController : Controller {
        
        [HttpPost]
        public ActionResult AddComment(Survey survey)
        {
            survey.Time = DateTime.Now;
            _context.Surveys.Add(survey);
            _context.SaveChanges();
            return Content("Added");
        }
    }
