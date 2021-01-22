    public ActionResult Tags(int articleId)
    {
        var article = repository.GetArticle();
        if (article !=null)
        {
            // Do your thing
        }
        else
        {
            return view("NotFound"); // or do something else
        }
    }
