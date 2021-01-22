    public override string FormatTags(string[] tagList)
    {
        // strip special tags
        string[] newTagList = stripTags(tagList);
        return base.FormatTags(newTagList);
    }
