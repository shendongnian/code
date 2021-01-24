    var list = new List<TweetDto> 
    {
        new TweetDto
        {
            screen_name = "nolan_dorris",
            text = "Some text"
        },
        new TweetDto
        {
            screen_name = "nolan_dorris",
            text = "Some text 2"
        },
        new TweetDto
        {
            screen_name = "imogene_kovacek",
            text = "Some text"
        }
    };
    var mapped = list
        .GroupBy(dto => dto.screen_name)
        .Select(group => new Dictionary<string, List<TweetDto>> 
        {
            { group.Key, group.ToList() }
        });
    var json = JsonConvert.SerializeObject(mapped, Formatting.Indented);
    Console.WriteLine(json);
