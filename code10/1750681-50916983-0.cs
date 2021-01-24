    public class PeopleController : AbpController
    {
        [HttpPost]
        [WrapResult(WrapOnSuccess = false, WrapOnError = false)]
        public JsonResult SavePerson(SavePersonModel person)
        {
            //TODO: save new person to database and return new person's id
            return Json(new {PersonId = 42});
        }
    }
