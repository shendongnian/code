    async protected override void OnAppearing()
    {
        if (listArticles != null && listArticles.Count > 0)
        {
           listArticles= articleView.getArticlesFromPlan();    
           PopulateOrderLists(listArticles);
        }
        base.OnAppearing();
    }
