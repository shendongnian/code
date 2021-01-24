    var list = new List<TweetDto>();
    list.Add(new TweetDto
    {
        screen_name = "nolan_dorris",
        text = "Some text"
    });
    list.Add(new TweetDto
    {
        screen_name = "nolan_dorris",
        text = "Some text 2"
    });
    list.Add(new TweetDto 
    { 
        screen_name = "imogene_kovacek",
        text = "Some text"
    });
    var mapped = list
        .GroupBy(dto => dto.screen_name)
        .Select(group => new Dictionary<string, List<TweetDto>> 
        {
            { group.Key, group.ToList() }
        });
    var json = JsonConvert.SerializeObject(mapped, Formatting.Indented);
    Console.WriteLine(json);
