    public static string TreeView<T>(IEnumerable<T> rootItems,
                                     Func<T, IEnumerable<T>> childrenProperty,
                                     Func<T, string> itemContent)
    {
        if (rootItems == null || !rootItems.Any()) return null;
        var builder = new StringBuilder();
        builder.AppendLine("<ul>");
        foreach (var item in rootItems)
        {
            builder.Append("  <li>").Append(itemContent(item)).AppendLine("</li>");
            var childContent = htmlHelper.TreeView(treeId,
                                                   childrenProperty(item),
                                                   childrenProperty,
                                                   itemContent);
            if (childContent != null)
            {
                var indented = childContent.Replace(Environment.NewLine,
                                                    Environment.NewLine + "  ");
                builder.Append("  ").AppendLine(indented);
            }
        }
        builder.Append("</ul>");
        return builder.ToString();
    }
