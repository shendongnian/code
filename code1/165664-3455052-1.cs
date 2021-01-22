    /// <summary>
    ///  Gets the inner XML of an <see cref="XElement"/>. Copied from
    ///  https://stackoverflow.com/questions/3793/best-way-to-get-innerxml-of-an-xelement
    /// </summary>
    /// <param name="element">The element.</param>
    /// <returns>The inner XML</returns>
    public static string GetInnerXml(this XElement element)
    {
    	var reader = element.CreateReader();
    	reader.MoveToContent();
    	return reader.ReadInnerXml();
    }
