    namespace DeleteMeQuestion.Controllers
    {
        [HandleError]
        public class HomeController : Controller
        {
            public ActionResult Index(int? id)
            {
                // TODO: get question to show based on method parameter 
                var model = GetModel(id);
                return View(model);
            }
            [HttpPost]
            public ActionResult Index(int? id, QuizModel model)
            {
                if (!ModelState.IsValid)
                {
                    var freshModel = GetModel(id);
                    return View(freshModel);
                }
                // TODO: save selected answer in database
                // TODO: get next question based on selected answer (hard coded to 999 for now)
                var nextQuestionId = 999;
                return RedirectToAction("Index", "Home", new {id = nextQuestionId});
            }
            private QuizModel GetModel(int? questionId)
            {
                // just a stub, in lieu of a database
                var model = new QuizModel
                {
                    QuestionDisplayText = questionId.HasValue ? "And so on..." : "What is your favorite color?",
                    QuestionId = 1,
                    Responses = new List<Response>
                                                    {
                                                        new Response
                                                            {
                                                                ChildQuestionId = 2,
                                                                ResponseId = 1,
                                                                ResponseDisplayText = "Red"
                                                            },
                                                        new Response
                                                            {
                                                                ChildQuestionId = 3,
                                                                ResponseId = 2,
                                                                ResponseDisplayText = "Blue"
                                                            },
                                                        new Response
                                                            {
                                                                ChildQuestionId = 4,
                                                                ResponseId = 3,
                                                                ResponseDisplayText = "Green"
                                                            },
                                                    }
                };
                return model;
            }
        }
    }
