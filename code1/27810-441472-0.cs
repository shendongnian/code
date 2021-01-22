    using DBParam = KeyValuePair<string, object>; // reduce need to keep re-typing this
    public void updatePost(int postId)
    {   
        List<DBParam> values = new List<DBParam>();
        values.Add(new DBParam("title", this.title));
        values.Add(new DBParam("newsContent", this.content));
        values.Add(new DBParam("excerpt", this.excerpt));
        values.Add(new DBParam("date", this.date));
        values.Add(new DBParam("urlTitle", this.urlTitle));
        values.Add(new DBParam("isPublished", this.isPublished));
    
        new DbConnection().updateQuery("news", values, new DBParam("id", postid));
    }
