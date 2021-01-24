    [HttpGet]
    public ActionResult Question()
        {
            Random rnd = new Random();
            int num1 = rnd.Next(13);
            int num2 = rnd.Next(13);
            return View(new QuestionViewModel
            {
                QuestionPart1 = num1,
                QuestionPart2 = num2,
            });
        }
        [HttpPost]
        public ActionResult Question(QuestionViewModel model)
        {
            //Check whether UserAnswer is true or false and increment values of them
            if (model.UserAnswer == (model.QuestionPart1 * model.QuestionPart2))
            {
                if (Session["QAnswered"] == null)
                    Session["QAnswered"] = 1;
                else
                    Session["QAnswered"] = int.Parse(Session["QAnswered"].ToString()) + 1;
            }
            else
            {
                if (Session["Failed"] == null)
                    Session["Failed"] = 1;
                else
                    Session["Failed"] = int.Parse(Session["Failed"].ToString()) + 1;
            }
            if (Session["QAnswered"] != null && int.Parse(Session["QAnswered"].ToString()) == 10)
            {
                // successful
                return RedirectToAction("Congratulation");
            }
            else
            {
                // failed
                return RedirectToAction("Question");
            }
        }
