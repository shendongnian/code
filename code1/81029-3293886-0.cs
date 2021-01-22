    public TagBuilder TextBox(this HtmlHelper helper, string name, string value)
    {
       var tag = new TagBuilder("input");
       tag.MergeAttribute("type", "text");
       tag.MergeAttribute("name", name);
       tag.MergeAttribute("value", value);
       return tag;
    }
