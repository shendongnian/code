    public static string TagCloud(this HtmlHelper html, IQueryable taggables, int numberOfStyleVariations, string divId)  
    {  
        var tags = new List<ITaggable>();  
        foreach (var obj in taggables)  
        {  
            tags.Add(obj as ITaggable);  
        }  
        return TagCloud(html, tags.AsQueryable<ITaggable>(), numberOfStyleVariations, divId);  
    }  
