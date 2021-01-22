    void ShowNews()
    {   
        User[] usersConcerned = News.GetAllUsersLinkedWithNews(); //only return the users concerned by the news
        List<News> news = News.GetAllNews();
        foreach(News item in news)
        {
           item.AddedByUser = usersConcerned.FirstOrDefault(u=>u.Id == item.AddedByUserID);
        }
        rptNewsStories.DataSource = news ; 
        rptNewsStories.DataBind();
    }
