    if (System.Web.HttpContext.Current.Session["Questions"] == null)
    {
        System.Web.HttpContext.Current.Session["Questions"] = Questions; // here question is string array, 
        //assigning value of array to session if session is null
    }
    else
    {
        string[] newQuestions = { "how are you?", "how do you do?" };
        string[] existingQuestions = (string[])HttpContext.Current.Session["Questions"];
        HttpContext.Current.Session["Questions"] = newQuestions.Union(existingQuestions).ToArray();
    }
