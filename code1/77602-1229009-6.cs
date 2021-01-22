    public static string ToStringWithDeclaration(this XDocument doc)
    {
        if (doc == null)
        {
            throw new ArgumentNullException("doc");
        }
        StringBuilder builder = new StringBuilder();
        using (TextWriter writer = new StringWriter(builder))
        {
            doc.Save(writer);
        }
        return builder.ToString();
    }
