    public ActionResult SaveAnswers(string actionType, Model model)
       {
          Answers userAnswers = new Answers();
        if (ModelState.IsValid)
        {
            if (actionType == "Save")
            {
                    userAnswers.value = model.answerValue[i];
                    db.SaveChanges();
     }
        }
        return View(actionType);
    }
