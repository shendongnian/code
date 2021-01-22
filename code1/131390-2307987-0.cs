    string classAttributePart = " class=\"first\"";
    foreach (var websitePage in websitePages)
    {
        sb.AppendLine(String.Format("<li" + classAttributePart + "><a href=\"{0}\">{1}</a></li>", websitePage.GetFileName(), websitePage.Title));
        classAttributePart = string.Empty;
    }
