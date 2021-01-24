    public ActionResult MyPage(){
         
         List<PoolManager.Models.Question> questionList = dbModel.Questions.ToList();
         
         TempData['answerList'] = dbModel.Answers/*.Where(//IF YOU WANT A WHERE CLAUSE YOU CAN WRITE HERE AS WELL)*/.ToList();
         //We just sent List<Answers> inside that TempData["answerList"], we will cast it in RazorPage later.
         
         return View(questionList);
    }
