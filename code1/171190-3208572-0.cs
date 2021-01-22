    public string TagsInput { get; set; }
    
    //further down
    var tagList = TagsInput.Split(Resources.GlobalResources.TagSeparator.ToCharArray()).ToList();
    tagList.ForEach(tag => tag = tag.Trim()); //trim each list item for spaces
    tagList.ForEach(tag => tag = tag.Replace(" ", "_")); //replace remaining inner word spacings with _
