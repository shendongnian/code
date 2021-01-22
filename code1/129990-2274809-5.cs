    List<NewsItem> itemList = new List<NewsItem>();
    itemList.Add(new NewsItemJoiner { AccountJoined = "fred" });
    itemList.Add(new NewsItemJoiner { AccountJoined = "pete" });
    itemList.Add(new NewsItemStatus { Status = "active" });
    itemList.Add(new NewsItemJoiner { AccountJoined = "jim" });
    itemList.Add(new NewsItemStatus { Status = "inactive" });
    NewsItemListRenderer renderer = new NewsItemListRenderer(itemList);
    Console.WriteLine(renderer.Render());
