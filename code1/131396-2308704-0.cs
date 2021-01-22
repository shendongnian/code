    public static class ExtenstionMethods
    {
		public static IEnumerable<KeyValuePair<Int32, T>> Indexed<T>(this IEnumerable<T> collection)
		{
			Int32 index = 0;
			foreach (var value in collection)
			{
				yield return new KeyValuePair<Int32, T>(index, value);
				++index;
			}
		}
    }
    foreach (var iter in websitePages.Indexed())
    {
        var websitePage = iter.Value;
        if(iter.Key == 0) classAttributePart = " class=\"first\"";
        sb.AppendLine(String.Format("<li" + classAttributePart + "><a href=\"{0}\">{1}</a></li>", websitePage.GetFileName(), websitePage.Title));
    }
