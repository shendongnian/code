    public ActionResult SubmitPoll(FormCollection model)
    {
        foreach(var key in model.AllKeys.where(x => x.StartsWith("txt_")) 
        {
            var value = model[key]
            var choiceId = key.Split('_')[1];
        }
    }
