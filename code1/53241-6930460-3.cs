    QueryStringBuilder parameters = new QueryStringBuilder()
        .Add("view", ViewBag.PageView)
        .Add("page", ViewBag.PageNumber)
        .Add("size", ViewBag.PageSize);
    string queryString = parameters.ToString();
