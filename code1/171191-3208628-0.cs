    public string[] TagsInput { get; set; }
    //further down
    var adjustedTags = new List<string>();
    foreach (var tag in TagsInput.Split(Resources.GlobalResources.TagSeparator.ToCharArray()))
    {
        adjustedTags.Add(tag.Trim().Replace(" ", "_"));
    }
    TagsInput = adjustedTags.ToArray();
