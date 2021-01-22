    Regex wordCounter = new Regex (@"\b(\w|[-'])+\b");
    IEnumerable<MedicalArticle> sqlQuery = dataContext.MedicalArticles
        .Where (article => article.Topic == "influenza");
    IEnumerable<MedicalArticle> localQuery = sqlQuery
        .Where (article => wordCounter.Matches (article.Abstract).Count < 100);
