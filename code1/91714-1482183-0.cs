    public ActionResult Tags(int articleId)
    {
        if (repository.ArticleExists(articleID))
        {
            // Do your thing
        }
        else
        {
            return view("NotFound"); // or do something else
        }
    }
